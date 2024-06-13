using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public class ECarParkingLot : BaseParkingLot<ECar> {
    public override bool Equals(object? obj)
    {
        return Equals(obj as ECarParkingLot);
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}
