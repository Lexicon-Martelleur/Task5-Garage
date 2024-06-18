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

    public ParkingLotInfoWithAddress? AddVehicleToGarage<VehicleType>(
        string addr,
        VehicleType vehicle
        // out ParkingLotInfoWithAddress? info
    )
        where VehicleType : IVehicle
    {
        var vehicleFactory = new VehicleFactory();

        ParkingLotInfoWithAddress? info = null;
        if ((vehicle as Car) != null && TryAddVehicle(
            _carGarages, addr, (vehicle as Car)!, out info))
        { return info; }

        if ((vehicle as IBus) != null && TryAddVehicle(
            _busGarages, addr, (vehicle as IBus)!, out info))
        { return info; }

        if ((vehicle as IMotorcycle) != null && TryAddVehicle(
            _mcGarages, addr, (vehicle as IMotorcycle)!, out info))
        { return info; }

        if ((vehicle as IBoat) != null && TryAddVehicle(
            _boatHarbors, addr, (vehicle as IBoat)!, out info))
        { return info; }

        if ((vehicle as IAirplane) != null && TryAddVehicle(
            _airplaneHangars, addr, (vehicle as IAirplane)!, out info))
        { return info; }

        if ((vehicle as ECar) != null && TryAddVehicle(
            _eCarGarages, addr, (vehicle as ECar)!, out info))
        { return info; }

        if (TryAddVehicle(_multiGarages, addr, (vehicle as IVehicle)!, out info))
        { return info; }

        // info = null;
        return info;
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
            out var parkingLot
        );
        
        if (parkingLot != null)
        {
            parkingLotInfo = new ParkingLotInfoWithAddress(
                new Address(address),
                parkingLot);
        }
        
        return result;
    }
}
