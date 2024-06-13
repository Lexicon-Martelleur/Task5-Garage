using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public class UniversalParkingLotFactory :
    IParkingLotFactory<IParkingLot<IVehicle>, IVehicle>
{
    public IParkingLot<IVehicle> Create(uint id)
    {
        return new UniversalParkingLot { ID = id };
    }
}
