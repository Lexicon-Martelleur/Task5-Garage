using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.Vehicle;

namespace Garage.Infrastructure.Store;

internal static class GarageInMemoryPopulator
{
    internal static (
        IEnumerable<IGarage<Car>> CarGarages,
        IEnumerable<IGarage<IBus>> BusGarages,
        IEnumerable<IGarage<IMotorcycle>> MCGarages,
        IEnumerable<IGarage<IBoat>> BoatHarbors,
        IEnumerable<IGarage<IAirplane>> AirplaneHangars,
        IEnumerable<IGarage<ECar>> ECarGarages,
        IEnumerable<IGarage<IVehicle>> MultiGarages
    ) CreateGarages()
    {

        var carGarageFactory = new GarageFactory<Car>();
        var carGarage = carGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1A"),
            GarageDescription.CAR_NO_ELECTRICAL_PARKING_LOTS);
        // PopulateCarGarage(carGarage);
        List<IGarage<Car>> CarGarages = [carGarage];

        var busFactory = new GarageFactory<IBus>();
        var busGarage = busFactory.CreateGarage(
            20,
            new Address("Garage Street 1B"),
            GarageDescription.BUS);
        // PopulateBusGarage(busGarage);
        List<IGarage<IBus>> BusGarages = [busGarage];

        var motorCycleGarageFactory = new GarageFactory<IMotorcycle>();
        var motorCycleGarage = motorCycleGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1C"),
            GarageDescription.MC);
        PopulateMCGarage(motorCycleGarage);
        List<IGarage<IMotorcycle>> MCGarages = [motorCycleGarage];

        var boatHarbourFactory = new GarageFactory<IBoat>();
        var boatHarbor = boatHarbourFactory.CreateGarage(
            20,
            new Address("Garage Street 1D"),
            GarageDescription.BOAT);
        PopulateBoatGarage(boatHarbor);
        List<IGarage<IBoat>> BoatHarbors = [boatHarbor];

        var airplaneHangarFactory = new GarageFactory<IAirplane>();
        var airplaneHangar = airplaneHangarFactory.CreateGarage(
            20,
            new Address("Garage Street 1E"),
            GarageDescription.AIRPLANE);
        PopulateAirplaneGarage(airplaneHangar);
        List<IGarage<IAirplane>> AirplaneHangars = [airplaneHangar];

        var eCarGarageFactory = new GarageFactory<ECar>();
        var eCarGarage = eCarGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1F"),
            GarageDescription.E_CAR);
        PopulateECarGarage(eCarGarage);
        List<IGarage<ECar>> ECarGarages = [eCarGarage];

        var universalGarageFactory = new GarageFactory<IVehicle>();
        var univarsalGarage = universalGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1G"),
            GarageDescription.MULTI);
        PopulateMultiGarage(univarsalGarage);

        var multiCarGarageFactory = new GarageFactory<IVehicle>();
        var multiCarGarage = multiCarGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1H"),
            GarageDescription.CAR);
        PopulateMultiCarGarage(multiCarGarage);
        List<IGarage<IVehicle>> MultiGarages = [univarsalGarage, multiCarGarage];

        return (
            CarGarages,
            BusGarages,
            MCGarages,
            BoatHarbors,
            AirplaneHangars,
            ECarGarages,
            MultiGarages
        );
    }

    private static void PopulateCarGarage(
        IGarage<Car> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            garage.AddVehicle(lot.ID, new Car(
                new RegistrationNumber($"ABC {++numberRegPart}"),
                CarBrand.FORD,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10)));
        }
    }

    private static void PopulateBusGarage(
        IGarage<IBus> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            garage.AddVehicle(lot.ID, new Bus(
                new RegistrationNumber($"BBC {++numberRegPart}"),
                10,
                10,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10)));
        }
    }
    private static void PopulateMCGarage(
        IGarage<IMotorcycle> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            garage.AddVehicle(lot.ID, new Motorcycle(
                new RegistrationNumber($"CBC {++numberRegPart}"),
                100,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10)));
        }
    }

    private static void PopulateBoatGarage(
        IGarage<IBoat> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            garage.AddVehicle(lot.ID, new Boat(
                new RegistrationNumber($"DBC {++numberRegPart}"),
                BoatSteeringMechanism.WHEEL,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10)));
        }
    }
    private static void PopulateAirplaneGarage(
        IGarage<IAirplane> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            garage.AddVehicle(lot.ID, new Airplane(
                new RegistrationNumber($"EBC {++numberRegPart}"),
                400,
                40,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10)));
        }
    }

    private static void PopulateECarGarage(
        IGarage<ECar> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            {
                garage.AddVehicle(lot.ID, new ECar(
                    new RegistrationNumber($"FBC {++numberRegPart}"),
                    CarBrand.FORD,
                    VehicleColor.GREY,
                    1000,
                    new Dimension(10, 10, 10)));
            }

        }
    }

    private static void PopulateMultiCarGarage(
        IGarage<IVehicle> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        uint counter = 0;
        foreach (var lot in parkingLots)
        {
            counter++;
            if (counter % 2 == 0)
            {
                garage.AddVehicle(lot.ID, new Car(
                    new RegistrationNumber($"GBC {++numberRegPart}"),
                    CarBrand.FORD,
                    VehicleColor.GREY,
                    PowerSource.GASOLINE,
                    1000,
                    new Dimension(10, 10, 10)));
            }
            else
            {
                garage.AddVehicle(lot.ID, new ECar(
                    new RegistrationNumber($"GBC {++numberRegPart}"),
                    CarBrand.FORD,
                    VehicleColor.GREY,
                    1000,
                    new Dimension(10, 10, 10)));
            }

        }
    }

    private static void PopulateMultiGarage(
        IGarage<IVehicle> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        for (int i = 0; i < 4; i++)
        {
            garage.AddVehicle(parkingLots[i].ID, new Car(
                new RegistrationNumber($"HBC {++numberRegPart}"),
                CarBrand.FORD,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10))
            );
        }
        for (int i = 4; i < 8; i++)
        {
            garage.AddVehicle(parkingLots[i].ID, new Bus(
                new RegistrationNumber($"HBC {++numberRegPart}"),
                10,
                10,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10))
            );
        }
        for (int i = 8; i < 12; i++)
        {
            garage.AddVehicle(parkingLots[i].ID, new ECar(
                new RegistrationNumber($"HBC {++numberRegPart}"),
                CarBrand.FORD,
                VehicleColor.GREY,
                1000,
                new Dimension(10, 10, 10))
            );
        }
        for (int i = 12; i < 20; i++)
        {
            garage.AddVehicle(parkingLots[i].ID, new Motorcycle(
                new RegistrationNumber($"HBC {++numberRegPart}"),
                100,
                VehicleColor.GREY,
                PowerSource.GASOLINE,
                1000,
                new Dimension(10, 10, 10))
            );
        }
    }
}
