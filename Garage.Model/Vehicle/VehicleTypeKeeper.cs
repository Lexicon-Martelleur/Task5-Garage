namespace Garage.Model.Vehicle;

/// <summary>
/// A class used to keep constant data related to the 
/// application supported vehicles.
/// </summary>
public static class VehicleTypeKeeper
{
    public readonly static VehicleTypeItem AIRPLANE = new("1", "Airplane");
    public readonly static VehicleTypeItem BOAT = new("2", "Boat");
    public readonly static VehicleTypeItem BUS = new("3", "Bus");
    public readonly static VehicleTypeItem CAR = new("4", "Car");
    public readonly static VehicleTypeItem E_CAR = new("5", "E-Car");
    public readonly static VehicleTypeItem MOTORCYCLE = new("6", "Motorcycle");
    public readonly static VehicleTypeItem DEFAULT = new("-1", "Default");

    public static readonly Dictionary<string, VehicleTypeItem> VehicleDescriptions = new()
    {
        { AIRPLANE.ID, AIRPLANE },
        { BOAT.ID, BOAT },
        { BUS.ID, BUS },
        { CAR.ID, CAR },
        { E_CAR.ID, E_CAR },
        { MOTORCYCLE.ID, MOTORCYCLE }
    };
}
