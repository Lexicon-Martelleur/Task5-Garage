using Garage.Model.Base;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public interface IGarageFactory<VehicleType>
    where VehicleType : IVehicle
{
    IGarage<VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        Address address,
        (string Description, string[] VehicleTypes) description);

    IGarage<VehicleType> CreateGarage(
        uint capacity,
        Address address,
        (string Description, string[] VehicleTypes) description);
}
