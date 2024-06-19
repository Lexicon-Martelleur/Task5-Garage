namespace Garage.Model.Vehicle;

public abstract class Vehicle(
    RegistrationNumber registrationNumber,
    string color,
    string powerSource,
    uint weight,
    Dimension dimension) : IVehicle
{
    public RegistrationNumber RegistrationNumber => registrationNumber;


    public string Color
    {
        get => color;
        set => color = value;
    }

    public string PowerSource => powerSource;

    public uint Weight => weight;

    public Dimension Dimension => dimension;

    public string Type => this.GetType().Name;

    public static Dictionary<string, string> GetPropertyDescriptionMap()
    {
        Dictionary<string, string> propertDescriptionMap = new()
        {
            { "Color", $"Select color or leave empty for any color [{VehicleColor.GREY}, " +
                $"{VehicleColor.WHITE}, " +
                $"{VehicleColor.BLACK}, " +
                $"{VehicleColor.BLUE}, " +
                $"{VehicleColor.RED}, " +
                $"{VehicleColor.MULTI}, " +
                $"{VehicleColor.UNKNOWN}]"
            },
            { "PowerSource", $"Select power source or leave empty for any source [{PowerSourceKeeper.GASOLINE}, " +
                $"{PowerSourceKeeper.DIESEL}, " +
                $"{PowerSourceKeeper.HYDROGEN}, " +
                $"{PowerSourceKeeper.ELECTRIC}, " +
                $"{PowerSourceKeeper.HYBRID}, " +
                $"{PowerSourceKeeper.NONE}, " +
                $"{PowerSourceKeeper.UNKNOWN}]"},
            { "Weight", "Enter exact weight (Number > 0) or leave empty for any weights"},
            { "Type", $"Select vehicle type or leave empty for any type [{VehicleTypeKeeper.AIRPLANE}, " +
                $"{VehicleTypeKeeper.BOAT}, " +
                $"{VehicleTypeKeeper.BUS}, " +
                $"{VehicleTypeKeeper.CAR}, " +
                $"{VehicleTypeKeeper.E_CAR}, " +
                $"{VehicleTypeKeeper.MOTORCYCLE}]"
            },
            { "Dimension", "Enter exact dimensions (x, y, z) or leave empty for any dimensions"},
        };

        return propertDescriptionMap;
    }
}
