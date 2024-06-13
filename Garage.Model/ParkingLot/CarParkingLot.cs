using Garage.Model.Vehicle;
namespace Garage.Model.ParkingLot;

internal class CarParkingLot : IParkingLot<ICar>
{
    private readonly uint _id;

    public uint ID
    {
        get => _id;
        init => _id = value;
    }

    public ICar? CurrentVehicle { get; set; }

    public bool Equals(IParkingLot<ICar>? other)
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
        return Equals(obj as CarParkingLot);
    }

    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
}
