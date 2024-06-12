using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public interface IParkingLot: IEquatable<IParkingLot>
{
    uint ID { get; init; }
    IVehicle? CurrentVehicle { get; set; }

}