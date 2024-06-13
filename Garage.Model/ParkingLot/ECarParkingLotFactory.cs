using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public class ECarParkingLotFactory : IParkingLotFactory<ECarParkingLot, ECar>
{
    public ECarParkingLot Create(uint id)
    {
        return new ECarParkingLot();
    }
}
