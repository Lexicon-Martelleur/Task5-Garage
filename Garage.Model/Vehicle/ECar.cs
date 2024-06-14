namespace Garage.Model.Vehicle;

public abstract class ECar : ICar
{
    public abstract RegistrationNumber RegistrationNumber { get; }

    public abstract CarBrand Brand { get; }

    public abstract string Color { get; set;  }
    public PowerSource PowerSource => PowerSource.ELECTRIC;

    public abstract uint Weight { get; }

    public abstract Dimension Dimension { get; }
}
