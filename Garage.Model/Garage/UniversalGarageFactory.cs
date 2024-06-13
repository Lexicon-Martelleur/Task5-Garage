using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class UniversalGarageFactory :
    IGarageFactory<IParkingLot<IVehicle>, IVehicle>
{
    public IGarage<IParkingLot<IVehicle>, IVehicle> CreateGarage(
        HashSet<IParkingLot<IVehicle>> parkingLots)
    {
        return new UniversalGarage<
            IParkingLot<IVehicle>,
            IVehicle
        >(parkingLots);
    }

    public IGarage<IParkingLot<IVehicle>, IVehicle> CreateGarage(uint capacity)
    {
        var parkingLotFactory = new UniversalParkingLotFactory();
        var parkingLots = GarageUtility<
            IParkingLot<IVehicle>,
            IVehicle
        >.CreateParkingLots(capacity, parkingLotFactory);
        return new UniversalGarage<
            IParkingLot<IVehicle>,
            IVehicle
        >(parkingLots);
    }
}
