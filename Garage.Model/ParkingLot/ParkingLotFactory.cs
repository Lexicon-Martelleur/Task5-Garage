namespace Garage.Model.ParkingLot;

public class ParkingLotFactory : IParkingLotFactory<GeneralParkingLot>
{
    public GeneralParkingLot Create(uint id)
    {
        return new GeneralParkingLot { ID = id };
    }
}
