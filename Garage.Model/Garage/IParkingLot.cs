using Garage.Model.Vehicle;

namespace Garage.Model.Garage
{
    public interface IParkingLot
    {
        IVehicle? CurrentVehicle { get; set; }
        uint ID { get; }
    }
}