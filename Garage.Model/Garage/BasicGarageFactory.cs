
namespace Garage.Model.Garage;

public class GarageFactory<ParkingLotType> : IGarageFactory<ParkingLotType>
    where ParkingLotType : IParkingLot, new()
{
    public Garage<ParkingLotType> CreateGarage(HashSet<ParkingLotType> parkingLots)
    {
        return new Garage<ParkingLotType>(parkingLots);
    }

    public Garage<ParkingLotType> CreateGarage(uint capacity)
    {
        return new Garage<ParkingLotType>(capacity);
    }
}
