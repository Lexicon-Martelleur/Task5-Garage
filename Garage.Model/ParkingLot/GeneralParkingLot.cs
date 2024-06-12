using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public class GeneralParkingLot : IParkingLot
{
    private readonly uint _id;

    public uint ID
    {
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

    public override bool Equals(object? obj)
    {
        return Equals(obj as GeneralParkingLot);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
}
