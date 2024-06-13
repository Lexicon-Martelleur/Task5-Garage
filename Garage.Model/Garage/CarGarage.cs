using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
namespace Garage.Model.Garage;

internal class CarGarage : BaseGarage<CarParkingLot, ICar>
{
    public CarGarage(
        uint capacity,
        IParkingLotFactory<CarParkingLot, ICar> parkingLotFactory) :
        base(capacity, parkingLotFactory) { }

    public CarGarage(HashSet<CarParkingLot> parkingLots) :
        base(parkingLots) { }
}
