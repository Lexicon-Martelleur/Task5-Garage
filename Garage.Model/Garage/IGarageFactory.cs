using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public interface IGarageFactory<VehicleType>
    where VehicleType : IVehicle
{
    IGarage<VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        string address,
        (string Garage, string Lot) description);

    IGarage<VehicleType> CreateGarage(
        uint capacity,
        string address,
        (string Garage, string Lot) description);
}
