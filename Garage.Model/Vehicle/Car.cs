namespace Garage.Model.Vehicle;

public class Car : Vehicle, ICar
{
    private readonly CarBrand _brand;
    
    public Car(
        RegistrationNumber registrationNumber,
        CarBrand brand,
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

    public CarBrand Brand => _brand;
}
