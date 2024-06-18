using Garage.Model.Base;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class GarageFactory<VehicleType> :
    IGarageFactory<VehicleType>
    where VehicleType : IVehicle
{
    public IGarage<VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        Address address,
        string description
    )
    {
        return new Garage<VehicleType>(
            parkingLots,
            address,
            description);
    }

    public IGarage<VehicleType> CreateGarage(
        uint capacity,
        Address address,
        string description
    )
    {
        var parkingLots = GarageUtility<
            IParkingLot<VehicleType>,
            VehicleType
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new Garage<VehicleType>(
            parkingLots,
            address,
            description);
    }

    private IParkingLot<VehicleType> CreateParkingLot(uint id)
    {
        return new ParkingLot<VehicleType>() { ID = id };
    }
}
