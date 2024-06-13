namespace Garage.Model.ParkingLot;

public class UniversalParkingLotFactory : IParkingLotFactory<UniversalParkingLot>
{
    public UniversalParkingLot Create(uint id)
    {
        return new UniversalParkingLot { ID = id };
    }
}
