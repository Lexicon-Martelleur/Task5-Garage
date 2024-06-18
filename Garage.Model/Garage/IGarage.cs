using Garage.Model.Base;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

/// <summary>
/// An interface describing a generics garage.
/// </summary>
/// <typeparam name="VehicleType">The type of vehicle</typeparam>
public interface IGarage<VehicleType> :
    IGarageInfo,
    IEnumerable<IParkingLot<VehicleType>>,
    IEquatable<IGarage<VehicleType>>
    where VehicleType : IVehicle
{
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

    IEnumerable<GroupedVehicle> GroupVehiclesByVehicleType();

    IParkingLot<VehicleType> GetFirstFreeParkingLot();
}