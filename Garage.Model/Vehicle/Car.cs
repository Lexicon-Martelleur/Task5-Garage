namespace Garage.Model.Vehicle;

public class Car : Vehicle, ICar
{
    private readonly string _brand;
    
    public Car(
        RegistrationNumber registrationNumber,
        string brand,
        string color,
        string powerSource,
        uint weight,
        Dimension dimension
    ) : base(
        registrationNumber,
        color,
        powerSource,
        weight,
        dimension
    ) {
        _brand = brand;
    }

    public string Brand => _brand;
}
