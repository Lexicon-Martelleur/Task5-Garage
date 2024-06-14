namespace Garage.Model.Vehicle;

public abstract class Vehicle(
    RegistrationNumber registrationNumber,
    string color,
    PowerSource powerSource,
    uint weight,
    Dimension dimension) : IVehicle
{
    public RegistrationNumber RegistrationNumber => registrationNumber;


    public string Color
    {
        get => color;
        set => color = value;
    }

    public PowerSource PowerSource => powerSource;

    public uint Weight => weight;

    public Dimension Dimension => dimension;
}
