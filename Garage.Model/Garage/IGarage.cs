using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

/// <summary>
/// An interface describing a generics garage.
/// </summary>
/// <typeparam name="VehicleType">The type of vehicle</typeparam>
public interface IGarage<VehicleType> :
    IEnumerable<IParkingLot<VehicleType>>, IEquatable<IGarage<VehicleType>>
    where VehicleType : IVehicle
{
    uint Capacity { get; }
    string Address { get; set; }
    string GarageDescription { get; init; }
    string ParkingLotDescription { get; init; }
    IParkingLot<VehicleType>[] ParkingLots { get; init; }
    bool IsFullGarage();
    bool IsOccupiedLot(IParkingLot<VehicleType> parkingLot);
    bool TryAddVehicle(
        uint parkingLotId,
        VehicleType vehicle,
        out IParkingLot<VehicleType>? parkingLot);
    bool TryRemoveVehicle(uint parkingLotId, out VehicleType? vehicle);


    /// <summary>
    /// Add a vehicle to a parking lot with specified id.
    /// </summary>
    /// <param name="parkingLotId"></param>
    /// <param name="vehicle"></param>
    /// <returns></returns>
    /// <exception cref="InvalidGarageStateException">
    /// Throws custom model exception parking lot with specified id does not exist.
    /// </exception>
    IParkingLot<VehicleType> AddVehicle(uint parkingLotId, VehicleType vehicle);

    /// <summary>
    /// Remove a vehicle to a parking lot with specified id.
    /// </summary>
    /// <param name="parkingLotId"></param>
    /// <returns></returns>
    /// <exception cref="InvalidGarageStateException">
    /// Throws custom model exception parking lot with specified id does not exist.
    /// </exception>
    VehicleType RemoveVehicle(uint parkingLotId);
}