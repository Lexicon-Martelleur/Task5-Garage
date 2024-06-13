using Garage.Model.Vehicle;


namespace Garage.Model.ParkingLot;

internal class CarParkingLotFactory : IParkingLotFactory<CarParkingLot, ICar>
{
    public CarParkingLot Create(uint id)
    {
        return new CarParkingLot();
    }
}
