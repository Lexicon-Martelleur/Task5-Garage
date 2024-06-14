using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class GarageFactory<VehicleType> :
    IGarageFactory<IParkingLot<VehicleType>, VehicleType>
    where VehicleType : IVehicle
{
    public IGarage<IParkingLot<VehicleType>, VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots
    )
    {
        return new UniversalGarage<IParkingLot<VehicleType>, VehicleType>(parkingLots);
    }

    public IGarage<IParkingLot<VehicleType>, VehicleType> CreateGarage(uint capacity)
    {
        var parkingLots = GarageUtility<
            IParkingLot<VehicleType>,
            VehicleType
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new UniversalGarage<IParkingLot<VehicleType>, VehicleType>(parkingLots);
    }

    private IParkingLot<VehicleType> CreateParkingLot(uint id)
    {
        return new ParkingLot<VehicleType>() { ID = id };
    }
}
