﻿using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.Vehicle;

namespace Garage.Infrastructure.Store;

/// <summary>
/// A class used to init <see cref="GarageInMemoryStore"/>
/// with data.
/// </summary>
internal static class GarageInMemoryPopulator
{
    internal static (
        List<IGarage<Car>> CarGarages,
        List<IGarage<ICar>> MultiCarGarages,
        List<IGarage<IBus>> BusGarages,
        List<IGarage<IMotorcycle>> MCGarages,
        List<IGarage<IBoat>> BoatHarbors,
        List<IGarage<IAirplane>> AirplaneHangars,
        List<IGarage<ECar>> ECarGarages,
        List<IGarage<IVehicle>> MultiGarages
    ) CreateGarages()
    {

        var carGarageFactory = new GarageFactory<Car>();
        var carGarage = carGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1A"),
            GarageDescriptionKeeper.CAR_NO_ELECTRICAL_PARKING_LOTS);
        // PopulateCarGarage(carGarage);
        List<IGarage<Car>> CarGarages = [carGarage];

        var allCarGarageFactory = new GarageFactory<ICar>();
        var allCarGarage = allCarGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1B"),
            GarageDescriptionKeeper.CAR);
        // PopulateAllCarGarage(carGarage);
        List<IGarage<ICar>> MultiCarGarages = [allCarGarage];

        var busFactory = new GarageFactory<IBus>();
        var busGarage = busFactory.CreateGarage(
            20,
            new Address("Garage Street 1C"),
            GarageDescriptionKeeper.BUS);
        // PopulateBusGarage(busGarage);
        List<IGarage<IBus>> BusGarages = [busGarage];

        var motorCycleGarageFactory = new GarageFactory<IMotorcycle>();
        var motorCycleGarage = motorCycleGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1D"),
            GarageDescriptionKeeper.MC);
        PopulateMCGarage(motorCycleGarage);
        List<IGarage<IMotorcycle>> MCGarages = [motorCycleGarage];

        var boatHarbourFactory = new GarageFactory<IBoat>();
        var boatHarbor = boatHarbourFactory.CreateGarage(
            20,
            new Address("Garage Street 1E"),
            GarageDescriptionKeeper.BOAT);
        PopulateBoatGarage(boatHarbor);
        List<IGarage<IBoat>> BoatHarbors = [boatHarbor];

        var airplaneHangarFactory = new GarageFactory<IAirplane>();
        var airplaneHangar = airplaneHangarFactory.CreateGarage(
            20,
            new Address("Garage Street 1F"),
            GarageDescriptionKeeper.AIRPLANE);
        PopulateAirplaneGarage(airplaneHangar);
        List<IGarage<IAirplane>> AirplaneHangars = [airplaneHangar];

        var eCarGarageFactory = new GarageFactory<ECar>();
        var eCarGarage = eCarGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1G"),
            GarageDescriptionKeeper.E_CAR);
        PopulateECarGarage(eCarGarage);
        List<IGarage<ECar>> ECarGarages = [eCarGarage];

        var universalGarageFactory = new GarageFactory<IVehicle>();
        var univarsalGarage = universalGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1H"),
            GarageDescriptionKeeper.MULTI);
        PopulateMultiGarage(univarsalGarage);

        var multiCarGarageFactory = new GarageFactory<IVehicle>();
        var multiCarGarage = multiCarGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1I"),
            GarageDescriptionKeeper.CAR);
        PopulateMultiCarGarage(multiCarGarage);
        List<IGarage<IVehicle>> MultiGarages = [univarsalGarage, multiCarGarage];

        return (
            CarGarages,
            MultiCarGarages,
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
                VehicleColor.BLUE,
                PowerSourceKeeper.GASOLINE,
                1000,
                new Dimension(10, 10, 10)));
        }
    }

    private static void PopulateAllCarGarage(
        IGarage<ICar> garage)
    {
        var parkingLots = garage.ParkingLots;
        uint numberRegPart = 100;
        foreach (var lot in parkingLots)
        {
            garage.AddVehicle(lot.ID, new Car(
                new RegistrationNumber($"ABC {++numberRegPart}"),
                CarBrand.FORD,
                VehicleColor.GREY,
                PowerSourceKeeper.HYBRID,
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
                VehicleColor.BLACK,
                PowerSourceKeeper.GASOLINE,
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
                VehicleColor.RED,
                PowerSourceKeeper.GASOLINE,
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
                VehicleColor.WHITE,
                PowerSourceKeeper.GASOLINE,
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
                PowerSourceKeeper.NONE,
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
                    VehicleColor.UNKNOWN,
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
                    PowerSourceKeeper.GASOLINE,
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
                PowerSourceKeeper.GASOLINE,
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
                PowerSourceKeeper.GASOLINE,
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
                PowerSourceKeeper.GASOLINE,
                1000,
                new Dimension(10, 10, 10))
            );
        }
    }
}
