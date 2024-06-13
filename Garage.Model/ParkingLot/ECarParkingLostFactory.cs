using Garage.Model.Vehicle;


namespace Garage.Model.ParkingLot;

internal class ECarParkingLotFactory : IParkingLotFactory<ECarParkingLot, ECar>
{
    public ECarParkingLot Create(uint id)
    {
        return new ECarParkingLot();
    }
}
