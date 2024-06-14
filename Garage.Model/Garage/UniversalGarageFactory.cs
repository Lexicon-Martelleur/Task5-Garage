using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class UniversalGarageFactory :
    IGarageFactory<IParkingLot<IVehicle>, IVehicle>
{
    public IGarage<IParkingLot<IVehicle>, IVehicle> CreateGarage(
        HashSet<IParkingLot<IVehicle>> parkingLots)
    {
        return new BaseGarage<
            IParkingLot<IVehicle>,
            IVehicle
        >(parkingLots);
    }

    public IGarage<IParkingLot<IVehicle>, IVehicle> CreateGarage(uint capacity)
    {
        var parkingLots = GarageUtility<
            IParkingLot<IVehicle>,
            IVehicle
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new BaseGarage<
            IParkingLot<IVehicle>,
            IVehicle
        >(parkingLots);
    }

    private ParkingLot<IVehicle> CreateParkingLot(uint id)
    {
        return new ParkingLot<IVehicle>() { ID = id };
    }
}
