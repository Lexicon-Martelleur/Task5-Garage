using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class ParkingLot(uint id) : IParkingLot
{
    public uint ID => id;

    public IVehicle? CurrentVehicle { get; set; }
}
