
using Garage.Model.ParkingLot;

namespace Garage.Model.Garage;

public interface IGarageFactory<ParkingLotType>
    where ParkingLotType : IParkingLot
{
    Garage<ParkingLotType> CreateGarage(HashSet<ParkingLotType> parkingLots);

    Garage<ParkingLotType> CreateGarage(uint capacity, IParkingLotFactory<ParkingLotType> parkingLotFactory);
}
