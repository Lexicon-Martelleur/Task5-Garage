using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class UniversalGarage<ParkingLotType, VehicleType> : BaseGarage<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    public UniversalGarage(
        uint capacity,
        IParkingLotFactory<ParkingLotType, VehicleType> parkingLotFactory) :
        base(capacity, parkingLotFactory) { }

    public UniversalGarage(HashSet<ParkingLotType> parkingLots) :
        base(parkingLots) { }
}
