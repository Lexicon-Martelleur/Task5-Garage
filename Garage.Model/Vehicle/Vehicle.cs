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

    public const string ColorKey = "Color";

    public const string PowerSourceKey = "PowerSource";

    public const string VehicleTypeKey = "VehicleType";

    public const string VehicleWeightKey = "Weight";

    public const string VehicleDimensionKey = "Dimension";

    public static Dictionary<string, string> GetPropertyDescriptionMap()
    {
        Dictionary<string, string> propertDescriptionMap = new()
        {
            { $"{ColorKey}", $"Select color or leave empty for any color [" +
                $"{VehicleColor.GREY.ToUpper()}, " +
                $"{VehicleColor.WHITE.ToUpper()}, " +
                $"{VehicleColor.BLACK.ToUpper()}, " +
                $"{VehicleColor.BLUE.ToUpper()}, " +
                $"{VehicleColor.RED.ToUpper()}, " +
                $"{VehicleColor.MULTI.ToUpper()}, " +
                $"{VehicleColor.UNKNOWN.ToUpper()}]"
            },
            { $"{PowerSourceKey}", $"Select power source or leave empty for any source [" +
                $"{PowerSourceKeeper.GASOLINE.ToUpper()}, " +
                $"{PowerSourceKeeper.DIESEL.ToUpper()}, " +
                $"{PowerSourceKeeper.HYDROGEN.ToUpper()}, " +
                $"{PowerSourceKeeper.ELECTRIC.ToUpper()}, " +
                $"{PowerSourceKeeper.HYBRID.ToUpper()}, " +
                $"{PowerSourceKeeper.NONE.ToUpper()}, " +
                $"{PowerSourceKeeper.UNKNOWN.ToUpper()}]"},
            { $"{VehicleTypeKey}", $"Select vehicle type or leave empty for any type [" +
                $"{VehicleTypeKeeper.AIRPLANE.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.BOAT.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.BUS.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.CAR.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.E_CAR.Description.ToUpper()}, " +
                $"{VehicleTypeKeeper.MOTORCYCLE.Description.ToUpper()}]"
            },
            { $"{VehicleWeightKey}", "Enter exact weight (Number > 0) or leave empty for any weights"},
            { $"{VehicleDimensionKey}", "Enter exact dimensions (x, y, z | x, y, z > 0) or leave empty for any dimensions"},
        };

        return propertDescriptionMap;
    }
}
