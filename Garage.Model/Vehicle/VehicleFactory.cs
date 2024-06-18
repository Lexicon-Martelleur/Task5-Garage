using System.Security.Cryptography;

namespace Garage.Model.Vehicle;

public class VehicleFactory
{
    public Car CreateGasolineCar(string regNumber)
    {
        return new Car(
            new RegistrationNumber(regNumber),
            CarBrand.FORD,
            VehicleColor.GREY,
            PowerSource.GASOLINE,
            1000,
            new Dimension(10, 10, 10)
        );
    }

    public IBus CreateBus(string regNumber)
    {
        return new Bus(
            new RegistrationNumber(regNumber),
            20,
            20,
            VehicleColor.GREY,
            PowerSource.GASOLINE,
            1000,
            new Dimension(10, 10, 10)
        );
    }

    public IMotorcycle CreateMC(string regNumber)
    {
        return new Motorcycle(
            new RegistrationNumber(regNumber),
            100,
            VehicleColor.GREY,
            PowerSource.GASOLINE,
            1000,
            new Dimension(10, 10, 10)
        );
    }

    public IBoat CreateBoat(string regNumber)
    {
        return new Boat(
            new RegistrationNumber(regNumber),
            BoatSteeringMechanism.WHEEL,
            VehicleColor.GREY,
            PowerSource.GASOLINE,
            1000,
            new Dimension(10, 10, 10)
        );
    }

    public IAirplane CreateAirplane(string regNumber)
    {
        return new Airplane(
            new RegistrationNumber(regNumber),
            20,
            200,
            VehicleColor.GREY,
            PowerSource.GASOLINE,
            1000,
            new Dimension(10, 10, 10)
        );
    }

    public ECar CreateECar(string regNumber)
    {
        return new ECar(
            new RegistrationNumber(regNumber),
            CarBrand.TESLA,
            VehicleColor.GREY,
            1000,
            new Dimension(10, 10, 10)
        );
    }
}
