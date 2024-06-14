namespace Garage.Model.Vehicle;

public class Boat : Vehicle, IBoat
{
    private readonly string _steeringMechanism;

    public Boat(
        RegistrationNumber registrationNumber,
        string steeringMechanism,
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
        _steeringMechanism = steeringMechanism;
    }

    public string SteeringMechanism => _steeringMechanism;
}

