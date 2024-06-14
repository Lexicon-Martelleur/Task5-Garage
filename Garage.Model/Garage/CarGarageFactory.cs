using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class CarGarageFactory : IGarageFactory<CarParkingLot, ICar>
{
    public IGarage<CarParkingLot, ICar> CreateGarage(
        HashSet<CarParkingLot> parkingLots)
    {
        return new BaseGarage<CarParkingLot, ICar>(parkingLots);
    }

    public IGarage<CarParkingLot, ICar> CreateGarage(uint capacity)
    {
        var parkingLots = GarageUtility<
            CarParkingLot,
            ICar
        >.CreateParkingLots(capacity, CreateCarParkingLot);
        return new BaseGarage<CarParkingLot, ICar>(parkingLots);
    }

    private CarParkingLot CreateCarParkingLot(uint id)
    {
        return new CarParkingLot() { ID = id };
    }
}
