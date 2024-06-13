using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class UniversalGarageFactory<ParkingLotType, VehicleType> :
    IGarageFactory<ParkingLotType, VehicleType>
    where VehicleType : IVehicle
    where ParkingLotType : IParkingLot<VehicleType>
{
    public IGarage<ParkingLotType, VehicleType> CreateGarage(
        HashSet<ParkingLotType> parkingLots)
    {
        return new UniversalGarage<ParkingLotType, VehicleType>(parkingLots);
    }

    public IGarage<ParkingLotType, VehicleType> CreateGarage(
        uint capacity,
        IParkingLotFactory<ParkingLotType, VehicleType> parkingLotFactory)
    {
        return new UniversalGarage<ParkingLotType, VehicleType>(capacity, parkingLotFactory);
    }
}
