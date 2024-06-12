
namespace Garage.Model.Garage;

public interface IGarageFactory<ParkingLotType>
    where ParkingLotType : IParkingLot, new()
{
    Garage<ParkingLotType> CreateGarage(HashSet<ParkingLotType> parkingLots);

    Garage<ParkingLotType> CreateGarage(uint capacity);
}
