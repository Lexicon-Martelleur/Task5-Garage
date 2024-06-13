using Garage.Model.ParkingLot;

namespace Garage.Model.Garage;

public class UniversalGarageFactory<ParkingLotType> : IGarageFactory<ParkingLotType>
   where ParkingLotType : IParkingLot
{
    public IGarage<ParkingLotType> CreateGarage(HashSet<ParkingLotType> parkingLots)
    {
        return new UniversalGarage<ParkingLotType>(parkingLots);
    }

    public IGarage<ParkingLotType> CreateGarage(uint capacity, IParkingLotFactory<ParkingLotType> parkingLotFactory)
    {
        return new UniversalGarage<ParkingLotType>(capacity, parkingLotFactory);
    }
}
