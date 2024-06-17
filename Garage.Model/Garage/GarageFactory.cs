using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class GarageFactory<VehicleType> :
    IGarageFactory<IParkingLot<VehicleType>, VehicleType>
    where VehicleType : IVehicle
{
    public IGarage<IParkingLot<VehicleType>, VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        string address,
        (string Garage, string Lot) description
    )
    {
        return new UniversalGarage<IParkingLot<VehicleType>, VehicleType>(
            parkingLots,
            address,
            description);
    }

    public IGarage<IParkingLot<VehicleType>, VehicleType> CreateGarage(
        uint capacity,
        string address,
        (string Garage, string Lot) description
    )
    {
        var parkingLots = GarageUtility<
            IParkingLot<VehicleType>,
            VehicleType
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new UniversalGarage<IParkingLot<VehicleType>, VehicleType>(
            parkingLots,
            address,
            description);
    }

    private IParkingLot<VehicleType> CreateParkingLot(uint id)
    {
        return new ParkingLot<VehicleType>() { ID = id };
    }
}
