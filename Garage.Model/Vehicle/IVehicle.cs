namespace Garage.Model.Vehicle;

public interface IVehicle
{
    string Type { get; }
    public RegistrationNumber RegistrationNumber { get; }

    public string Color { get; set; }

    public string PowerSource { get; }

    public uint Weight { get; }

    public Dimension Dimension { get; }
}
