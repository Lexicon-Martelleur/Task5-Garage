namespace Garage.Model.Vehicle;

public interface ICar : IVehicle
{
    public CarBrand Brand { get; }
}
