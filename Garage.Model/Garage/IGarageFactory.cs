using Garage.Model.ParkingLot;

namespace Garage.Model.Garage;

public interface IGarageFactory<ParkingLotType>
    where ParkingLotType : IParkingLot
{
    IGarage<ParkingLotType> CreateGarage(HashSet<ParkingLotType> parkingLots);

    IGarage<ParkingLotType> CreateGarage(uint capacity, IParkingLotFactory<ParkingLotType> parkingLotFactory);
}
