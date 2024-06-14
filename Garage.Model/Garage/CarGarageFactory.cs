using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class CarGarageFactory : IGarageFactory<ParkingLot<ICar>, ICar>
{
    public IGarage<ParkingLot<ICar>, ICar> CreateGarage(
        HashSet<ParkingLot<ICar>> parkingLots)
    {
        return new BaseGarage<ParkingLot<ICar>, ICar>(parkingLots);
    }

    public IGarage<ParkingLot<ICar>, ICar> CreateGarage(uint capacity)
    {
        var parkingLots = GarageUtility<
            ParkingLot<ICar>,
            ICar
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new BaseGarage<ParkingLot<ICar>, ICar>(parkingLots);
    }

    private ParkingLot<ICar> CreateParkingLot(uint id)
    {
        return new ParkingLot<ICar>() { ID = id };
    }
}
