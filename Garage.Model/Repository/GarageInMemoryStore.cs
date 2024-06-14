//using Garage.Model.Garage;
//using Garage.Model.ParkingLot;
//using Garage.Model.Repository;
//using Garage.Model.Service;
//using Garage.Model.Vehicle;

//namespace Garage.Application.controller;

//public class GarageInMemoryStore : IGarageRepository
//{
//    private GarageHolder _garages;

//    public GarageInMemoryStore()
//    {
//        _garages = CreateGarages();
//    }

//    public GarageHolder GetAllGarages()
//    {
//        return CreateGarages();
//    }

//    private GarageHolder CreateGarages()
//    {
//        //var universalGarageFactory = new GarageFactory<IVehicle>();
//        //var univarsalGarage = universalGarageFactory.CreateGarage(20);

//        var carGarageFactory = new GarageFactory<ICar>();
//        var carGarage = carGarageFactory.CreateGarage(20, "ADDRESS", GarageDescription.CAR);
//        PopulateCarGarage(carGarage);

//        //var eCarGarageFactory = new GarageFactory<ECar>();
//        //var eCarGarage = eCarGarageFactory.CreateGarage(20);

//        var busFactory = new GarageFactory<IBus>();
//        var busGarage = busFactory.CreateGarage(20, "ADDRESS", GarageDescription.BUS);
//        PopulateBusGarage(busGarage);

//        var motorCycleGarageFactory = new GarageFactory<IMotorcycle>();
//        var motorCycleGarage = motorCycleGarageFactory.CreateGarage(20, "ADDRESS", GarageDescription.MC);
//        PopulateMCGarage(motorCycleGarage);

//        var boatHarbourFactory = new GarageFactory<IBoat>();
//        var boatHarbour = boatHarbourFactory.CreateGarage(20, "ADDRESS", GarageDescription.BOAT);
//        PopulateBoatGarage(boatHarbour);

//        var airplaneHangarFactory = new GarageFactory<IAirplane>();
//        var airplaneHangar = airplaneHangarFactory.CreateGarage(20, "ADDRESS", GarageDescription.AIRPLANE);
//        PopulateAirplaneGarage(airplaneHangar);


//        return new GarageHolder() 
//        {
//            CarGarages = [carGarage],
//            BusGarages = [busGarage],
//            MCGarages = [motorCycleGarage],
//            BoatHarbors = [boatHarbour],
//            AirplaneHangars = [airplaneHangar]
//        };
//    }
//    private void PopulateCarGarage(
//        IGarage<IParkingLot<ICar>, ICar> garage)
//    {
//        var parkingLots = garage.ParkingLots;
//        foreach (var lot in parkingLots)
//        {
//            garage.AddVehicle(lot.ID, new Car(
//                new RegistrationNumber("XXX"),
//                CarBrand.FORD,
//                VehicleColor.GREY,
//                PowerSource.GASOLINE,
//                1000,
//                new Dimension(10, 10, 10)));

//        }
//    }

//    private void PopulateBusGarage(
//        IGarage<IParkingLot<IBus>, IBus> garage)
//    {
//        var parkingLots = garage.ParkingLots;
//        foreach (var lot in parkingLots)
//        {
//            garage.AddVehicle(lot.ID, new Bus(
//                new RegistrationNumber("XXX"),
//                10,
//                10,
//                VehicleColor.GREY,
//                PowerSource.GASOLINE,
//                1000,
//                new Dimension(10, 10, 10)));
//        }
//    }
//    private void PopulateMCGarage(
//        IGarage<IParkingLot<IMotorcycle>, IMotorcycle> garage)
//    {
//        var parkingLots = garage.ParkingLots;
//        foreach (var lot in parkingLots)
//        {
//            garage.AddVehicle(lot.ID, new Motorcycle(
//                new RegistrationNumber("XXX"),
//                100,
//                VehicleColor.GREY,
//                PowerSource.GASOLINE,
//                1000,
//                new Dimension(10, 10, 10)));
//        }
//    }

//    private void PopulateBoatGarage(
//        IGarage<IParkingLot<IBoat>, IBoat> garage)
//    {
//        var parkingLots = garage.ParkingLots;
//        foreach (var lot in parkingLots)
//        {

//            garage.AddVehicle(lot.ID, new Boat(
//                new RegistrationNumber("XXX"),
//                BoatSteeringMechanism.WHEEL,
//                VehicleColor.GREY,
//                PowerSource.GASOLINE,
//                1000,
//                new Dimension(10, 10, 10)));
//        }
//    }
//    private void PopulateAirplaneGarage(
//        IGarage<IParkingLot<IAirplane>, IAirplane> garage)
//    {
//        var parkingLots = garage.ParkingLots;
//        foreach (var lot in parkingLots)
//        {
//            garage.AddVehicle(lot.ID, new Airplane(
//                new RegistrationNumber("XXX"),
//                400,
//                40,
//                VehicleColor.GREY,
//                PowerSource.GASOLINE,
//                1000,
//                new Dimension(10, 10, 10)));
//        }
//    }
//}