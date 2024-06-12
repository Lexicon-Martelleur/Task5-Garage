
using Garage.Model.ParkingLot;

namespace Garage.Model.Garage;

public class BasicGarageFactory<ParkingLotType> : IGarageFactory<ParkingLotType>
   where ParkingLotType : IParkingLot
{
    public Garage<ParkingLotType> CreateGarage(HashSet<ParkingLotType> parkingLots)
    {
        return new Garage<ParkingLotType>(parkingLots);
    }

    public Garage<ParkingLotType> CreateGarage(uint capacity, IParkingLotFactory<ParkingLotType> parkingLotFactory)
    {
        return new Garage<ParkingLotType>(capacity, parkingLotFactory);
    }
}
