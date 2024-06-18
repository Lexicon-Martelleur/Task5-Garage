using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;

namespace Garage.Infrastructure.Store;

public class GarageInMemoryStore : IGarageRepository
{

    private IEnumerable<IGarage<Car>> _carGarages = [];

    private IEnumerable<IGarage<IBus>> _busGarages = [];

    private IEnumerable<IGarage<IMotorcycle>> _mcGarages = [];

    private IEnumerable<IGarage<IBoat>> _boatHarbors = [];

    private IEnumerable<IGarage<IAirplane>> _airplaneHangars = [];

    private IEnumerable<IGarage<ECar>> _eCarGarages = [];

    private IEnumerable<IGarage<IVehicle>> _multiGarages = [];

    public GarageInMemoryStore()
    {
        CreateGarages();
    }

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(Address garageAddress)
    {
        return GetGroupedVehiclesInGarage(garageAddress);
    }

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesInGarage(Address garageAddress)
    {
        var carGarage = _carGarages
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (carGarage != null) { return carGarage.GroupVehiclesByVehicleType(); }

        var busGarage = _busGarages
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (busGarage != null) { return busGarage.GroupVehiclesByVehicleType(); }

        var mcGarage = _mcGarages
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (mcGarage != null) { return mcGarage.GroupVehiclesByVehicleType(); }

        var airplaneHanagars = _airplaneHangars
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (airplaneHanagars != null) { return airplaneHanagars.GroupVehiclesByVehicleType(); }

        var boatHarbors = _boatHarbors
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (boatHarbors != null) { return boatHarbors.GroupVehiclesByVehicleType(); }

        var eCarGarage = _eCarGarages
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (eCarGarage != null) { return eCarGarage.GroupVehiclesByVehicleType(); }

        var multiGarage = _multiGarages
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (multiGarage != null) { return multiGarage.GroupVehiclesByVehicleType(); }

        return null;
    }

    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages()
    {
        List<GarageInfoWithVehicleTypeName> garageInfoItems = [];

        garageInfoItems.AddRange(_carGarages.Select(garage => new GarageInfoWithVehicleTypeName(
            garage)));

        garageInfoItems.AddRange(_busGarages.Select(garage => new GarageInfoWithVehicleTypeName(
            garage)));

        garageInfoItems.AddRange(_mcGarages.Select(garage => new GarageInfoWithVehicleTypeName(
            garage)));

        garageInfoItems.AddRange(_boatHarbors.Select(garage => new GarageInfoWithVehicleTypeName(
            garage)));

        garageInfoItems.AddRange(_airplaneHangars.Select(garage => new GarageInfoWithVehicleTypeName(
             garage)));

        garageInfoItems.AddRange(_eCarGarages.Select(garage => new GarageInfoWithVehicleTypeName(
            garage)));

        garageInfoItems.AddRange(_multiGarages.Select(garage => new GarageInfoWithVehicleTypeName(
            garage)));

        return garageInfoItems;
    }

    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles()
    {
        List<ParkingLotInfoWithAddress> parkingLotsInfo = [];
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_carGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_busGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_mcGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_boatHarbors));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_airplaneHangars));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_eCarGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(_multiGarages));
        return parkingLotsInfo;
    }

    private List<ParkingLotInfoWithAddress> GetParkingLotsInfoFromGarages<VehicleType>(
        IEnumerable<IGarage<VehicleType>> garages)
        where VehicleType : IVehicle
    {
        List<ParkingLotInfoWithAddress> parkingLotsInfo = [];
        foreach (var garage in garages)
        {
            parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarage(
                garage
            ));
        }
        return parkingLotsInfo;
    }

    private List<ParkingLotInfoWithAddress> GetParkingLotsInfoFromGarage<VehicleType>(
        IGarage<VehicleType> garage)
        where VehicleType : IVehicle
    {
        List<ParkingLotInfoWithAddress> parkingLotsInfo = [];
        foreach (var lot in garage.ParkingLots)
        {
            if (lot.CurrentVehicle == null) { continue; }

            parkingLotsInfo.Add(new ParkingLotInfoWithAddress(
                garage.Address,
                lot
            ));
        }
        return parkingLotsInfo;
    }

    private void CreateGarages()
    {
        
        var carGarageFactory = new GarageFactory<Car>();
        var carGarage = carGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1A"),
            GarageDescription.CAR_NO_ELECTRICAL_PARKING_LOTS);
        // PopulateCarGarage(carGarage);
        _carGarages = [carGarage];

        var busFactory = new GarageFactory<IBus>();
        var busGarage = busFactory.CreateGarage(
            20,
            new Address("Garage Street 1B"),
            GarageDescription.BUS);
        PopulateBusGarage(busGarage);
        _busGarages = [busGarage];

        var motorCycleGarageFactory = new GarageFactory<IMotorcycle>();
        var motorCycleGarage = motorCycleGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1C"),
            GarageDescription.MC);
        PopulateMCGarage(motorCycleGarage);
        _mcGarages = [motorCycleGarage];

        var boatHarbourFactory = new GarageFactory<IBoat>();
        var boatHarbour = boatHarbourFactory.CreateGarage(
            20,
            new Address("Garage Street 1D"),
            GarageDescription.BOAT);
        PopulateBoatGarage(boatHarbour);
        _boatHarbors = [boatHarbour];

        var airplaneHangarFactory = new GarageFactory<IAirplane>();
        var airplaneHangar = airplaneHangarFactory.CreateGarage(
            20,
            new Address("Garage Street 1E"),
            GarageDescription.AIRPLANE);
        PopulateAirplaneGarage(airplaneHangar);
        _airplaneHangars = [airplaneHangar];

        var eCarGarageFactory = new GarageFactory<ECar>();
        var eCarGarage = eCarGarageFactory.CreateGarage(
            20,
            new Address("Garage Street 1F"),
            GarageDescription.E_CAR);
        PopulateECarGarage(eCarGarage);
        _eCarGarages = [eCarGarage];

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
        _multiGarages = [univarsalGarage, multiCarGarage];
    }

    private void PopulateCarGarage(
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

    private void PopulateBusGarage(
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
    private void PopulateMCGarage(
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

    private void PopulateBoatGarage(
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
    private void PopulateAirplaneGarage(
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

    private void PopulateECarGarage(
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

    private void PopulateMultiCarGarage(
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

    private void PopulateMultiGarage(
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

    public bool AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType,
        out ParkingLotInfoWithAddress? parkingLotInfo)
    {
        var isVehicleAdded = TryAddCar(
            address, regNumber, vehicleType, out parkingLotInfo);
        if (isVehicleAdded) { return true; }

        return false;
    }

    private bool TryAddCar(
        string address,
        string regNumber,
        string vehicleType,
        out ParkingLotInfoWithAddress? parkingLotInfo)
    {
        parkingLotInfo = null;
        var garage = _carGarages
            .Where(garage => garage.Address.Value == address)
            .FirstOrDefault();
        if (garage != null && !garage.IsFullGarage() && vehicleType == VehicleType.CAR)
        {
            var result = garage.TryAddVehicle(
                garage.GetFistFreeParkingLot().ID,
                new Car(
                    new RegistrationNumber(regNumber),
                    CarBrand.FORD,
                    VehicleColor.GREY,
                    PowerSource.GASOLINE,
                    1000,
                    new Dimension(10, 10, 10)),
                 out IParkingLot<Car>? parkingLot
            );
            if (parkingLot != null){
                parkingLotInfo = new ParkingLotInfoWithAddress(
                    new Address(address),
                    parkingLot
                );
            }
            return result;
        }
        return false;
    }
}
