
namespace Garage.Model.ParkingLot;

public interface IParkingLotFactory<ParkingLotType>
    where ParkingLotType : IParkingLot
{
    ParkingLotType Create(uint id);
}
