namespace Garage.Model.Vehicle;

public class ECar : Vehicle, ICar
{
    private readonly CarBrand _brand;

    public ECar(
        RegistrationNumber registrationNumber,
        CarBrand brand,
        string color,
        uint weight,
        Dimension dimension
    ) : base(
        registrationNumber,
        color,
        PowerSource.ELECTRIC,
        weight,
        dimension
    )
    {
        _brand = brand;
    }

    public CarBrand Brand => _brand;
}
