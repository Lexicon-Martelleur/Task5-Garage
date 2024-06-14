using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage
{
    public interface IGarage<ParkingLotType, VehicleType> : IEnumerable<ParkingLotType>
        where VehicleType : IVehicle
        where ParkingLotType : IParkingLot<VehicleType>
    {
        uint Capacity { get; }
        string Address { get; set; }
        string Description { get; set; }
        ParkingLotType[] ParkingLots { get; init; }
        bool IsFullGarage();
        bool IsOccupiedLot(ParkingLotType parkingLot);
        bool TryAddVehicle(uint parkingLotId, VehicleType vehicle, out ParkingLotType? parkingLot);
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
        ParkingLotType AddVehicle(uint parkingLotId, VehicleType vehicle);

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
}