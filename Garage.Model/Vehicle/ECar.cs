namespace Garage.Model.Vehicle;

internal class ECar : ICar
{
    public RegistrationNumber RegistrationNumber => throw new NotImplementedException();

    public CarBrand Brand => throw new NotImplementedException();

    public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public PowerSource PowerSource => PowerSource.ELECTRIC;
}
