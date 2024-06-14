namespace Garage.Model.Vehicle;


public class Motorcycle : Vehicle, IMotorcycle
{
    private uint _noiseLevel;

    public Motorcycle(
        RegistrationNumber registrationNumber,
        uint noiseLevel,
        string color,
        PowerSource powerSource,
        uint weight,
        Dimension dimension
    ) : base(
        registrationNumber,
        color,
        powerSource,
        weight,
        dimension
    )
    {
        _noiseLevel = noiseLevel;
    }

    public uint NoiseLevel {
        get => _noiseLevel;
        set => _noiseLevel = value;
    }
}

