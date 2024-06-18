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
        var garages = GarageInMemoryPopulator.CreateGarages();
        _carGarages = garages.CarGarages;
        _busGarages = garages.BusGarages;
        _mcGarages = garages.MCGarages;
        _boatHarbors = garages.BoatHarbors;
        _airplaneHangars = garages.AirplaneHangars;
        _eCarGarages = garages.ECarGarages;
        _multiGarages = garages.MultiGarages;
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

    //private void CreateGarages()
    //{
        
    //    var carGarageFactory = new GarageFactory<Car>();
    //    var carGarage = carGarageFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1A"),
    //        GarageDescription.CAR_NO_ELECTRICAL_PARKING_LOTS);
    //    // GarageInMemoryPopulator.PopulateCarGarage(carGarage);
    //    _carGarages = [carGarage];

    //    var busFactory = new GarageFactory<IBus>();
    //    var busGarage = busFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1B"),
    //        GarageDescription.BUS);
    //    // GarageInMemoryPopulator.PopulateBusGarage(busGarage);
    //    _busGarages = [busGarage];

    //    var motorCycleGarageFactory = new GarageFactory<IMotorcycle>();
    //    var motorCycleGarage = motorCycleGarageFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1C"),
    //        GarageDescription.MC);
    //    GarageInMemoryPopulator.PopulateMCGarage(motorCycleGarage);
    //    _mcGarages = [motorCycleGarage];

    //    var boatHarbourFactory = new GarageFactory<IBoat>();
    //    var boatHarbour = boatHarbourFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1D"),
    //        GarageDescription.BOAT);
    //    GarageInMemoryPopulator.PopulateBoatGarage(boatHarbour);
    //    _boatHarbors = [boatHarbour];

    //    var airplaneHangarFactory = new GarageFactory<IAirplane>();
    //    var airplaneHangar = airplaneHangarFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1E"),
    //        GarageDescription.AIRPLANE);
    //    GarageInMemoryPopulator.PopulateAirplaneGarage(airplaneHangar);
    //    _airplaneHangars = [airplaneHangar];

    //    var eCarGarageFactory = new GarageFactory<ECar>();
    //    var eCarGarage = eCarGarageFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1F"),
    //        GarageDescription.E_CAR);
    //    GarageInMemoryPopulator.PopulateECarGarage(eCarGarage);
    //    _eCarGarages = [eCarGarage];

    //    var universalGarageFactory = new GarageFactory<IVehicle>();
    //    var univarsalGarage = universalGarageFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1G"),
    //        GarageDescription.MULTI);
    //    GarageInMemoryPopulator.PopulateMultiGarage(univarsalGarage);

    //    var multiCarGarageFactory = new GarageFactory<IVehicle>();
    //    var multiCarGarage = multiCarGarageFactory.CreateGarage(
    //        20,
    //        new Address("Garage Street 1H"),
    //        GarageDescription.CAR);
    //    GarageInMemoryPopulator.PopulateMultiCarGarage(multiCarGarage);
    //    _multiGarages = [univarsalGarage, multiCarGarage];
    //}


    public bool AddVehicleToGarage<VehicleType>(
        string addr,
        VehicleType vehicle,
        out ParkingLotInfoWithAddress? info
    )
        where VehicleType : IVehicle
    {
        var vehicleFactory = new VehicleFactory();

        if ((vehicle as Car) != null && TryAddVehicle(
            _carGarages, addr, (vehicle as Car)!, out info))
        { return true; }

        if ((vehicle as IBus) != null && TryAddVehicle(
            _busGarages, addr, (vehicle as IBus)!, out info))
        { return true; }

        if ((vehicle as IMotorcycle) != null && TryAddVehicle(
            _mcGarages, addr, (vehicle as IMotorcycle)!, out info))
        { return true; }

        if ((vehicle as IBoat) != null && TryAddVehicle(
            _boatHarbors, addr, (vehicle as IBoat)!, out info))
        { return true; }

        if ((vehicle as IAirplane) != null && TryAddVehicle(
            _airplaneHangars, addr, (vehicle as IAirplane)!, out info))
        { return true; }

        if ((vehicle as ECar) != null && TryAddVehicle(
            _eCarGarages, addr, (vehicle as ECar)!, out info))
        { return true; }

        if (TryAddVehicle(_multiGarages, addr, (vehicle as IVehicle)!, out info))
        { return true; }

        info = null;
        return false;
    }

    public bool TryAddVehicle<VehicleType, GarageType>(
        IEnumerable<GarageType> garages,
        string address,
        VehicleType vehicle,
        out ParkingLotInfoWithAddress? parkingLotInfo
    )
        where VehicleType : IVehicle
        where GarageType : IGarage<VehicleType>
    {
        parkingLotInfo = null;
        var garage = garages
            .Where(garage => garage.Address.Value == address)
            .FirstOrDefault();
        
        if (garage == null || garage.IsFullGarage())
        {
            return false;
        }

        var result = garage.TryAddVehicle(
            garage.GetFirstFreeParkingLot().ID,
            vehicle,
            out var parkingLot);
        
        if (parkingLot != null)
        {
            parkingLotInfo = new ParkingLotInfoWithAddress(
                new Address(address),
                parkingLot);
        }
        
        return result;
    }
}
