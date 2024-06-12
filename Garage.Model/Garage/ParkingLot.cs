using Garage.Model.Vehicle;
using System.Diagnostics.CodeAnalysis;

namespace Garage.Model.Garage;

public class ParkingLot : IParkingLot
{
    private readonly uint _id;

    public uint ID { 
        get => _id;
        init => _id = value;
    }

    public IVehicle? CurrentVehicle { get; set; }

    public bool Equals(IParkingLot? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return _id == other.ID;
    }
}
