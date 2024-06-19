namespace Garage.Model.Vehicle;

// TODO! Fix static creation of vehicle properties.
// TODO! Update to write all properties or use unknown to simplify.
public class VehicleFactory
{
    public Car CreateGasolineCar(string regNumber)
    {
        return new Car(
            new RegistrationNumber(regNumber),
            CarBrand.FORD,
            VehicleColor.GREY,
            PowerSourceKeeper.GASOLINE,
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
            PowerSourceKeeper.GASOLINE,
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
            PowerSourceKeeper.GASOLINE,
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
            PowerSourceKeeper.GASOLINE,
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
            PowerSourceKeeper.GASOLINE,
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
