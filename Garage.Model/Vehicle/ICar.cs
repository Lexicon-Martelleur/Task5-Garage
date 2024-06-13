namespace Garage.Model.Vehicle;

public interface ICar : IVehicle
{
    public RegistrationNumber RegistrationNumber { get; }

    public CarBrand Brand { get; }
}
