using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
namespace Garage.Model.Garage;

internal class CarGarage : BaseGarage<CarParkingLot, ICar>
{
    public CarGarage(HashSet<CarParkingLot> parkingLots) :
        base(parkingLots) { }
}
