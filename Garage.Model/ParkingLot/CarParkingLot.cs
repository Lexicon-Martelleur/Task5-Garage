using Garage.Model.Vehicle;
namespace Garage.Model.ParkingLot;

public class CarParkingLot : BaseParkingLot<ICar> {
    public override bool Equals(object? obj)
    {
        return Equals(obj as CarParkingLot);
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}
