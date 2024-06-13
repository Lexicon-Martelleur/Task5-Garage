using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

internal class CarGarageFactory : IGarageFactory<CarParkingLot, ICar>
{
    public IGarage<CarParkingLot, ICar> CreateGarage(
        HashSet<CarParkingLot> parkingLots)
    {
        return new CarGarage(parkingLots);
    }

    public IGarage<CarParkingLot, ICar> CreateGarage(
        uint capacity,
        IParkingLotFactory<CarParkingLot, ICar> parkingLotFactory)
    {
        return new CarGarage(capacity, parkingLotFactory);
    }
}
