namespace Garage.Model.Vehicle;

public class ECar : Vehicle, ICar
{
    private readonly string _brand;

    public ECar(
        RegistrationNumber registrationNumber,
        string brand,
        string color,
        uint weight,
        Dimension dimension
    ) : base(
        registrationNumber,
        color,
        PowerSourceKeeper.ELECTRIC,
        weight,
        dimension
    )
    {
        _brand = brand;
    }

    public string Brand => _brand;
}
