using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;
using System.Reflection;

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

        garageInfoItems.AddRange(_carGarages.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

        garageInfoItems.AddRange(_busGarages.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

        garageInfoItems.AddRange(_mcGarages.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

        garageInfoItems.AddRange(_boatHarbors.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

        garageInfoItems.AddRange(_airplaneHangars.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

        garageInfoItems.AddRange(_eCarGarages.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

        garageInfoItems.AddRange(_multiGarages.Select(
            garage => new GarageInfoWithVehicleTypeName(garage)));

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

    public IGarageInfo? GetGarage(string addr)
    {
        var carGarage = _carGarages
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if ( carGarage != null ) { return carGarage; }

        var busGarage = _busGarages
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if (busGarage != null) { return busGarage; }

        var mcGarage = _mcGarages
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if (mcGarage != null) { return mcGarage; }

        var boatHarbor = _boatHarbors
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if (boatHarbor != null) { return boatHarbor; }

        var airplaneHangar = _airplaneHangars
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if (airplaneHangar != null) { return airplaneHangar; }

        var multiGarage = _multiGarages
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if (multiGarage != null) { return multiGarage; }

        return null;
    }

    public ParkingLotInfoWithAddress? AddVehicleToGarage<VehicleType>(
        string addr,
        VehicleType vehicle
    )
        where VehicleType : IVehicle
    {
        var selectedGarage = GetGarage(addr);
        if ( selectedGarage == null) { return null; }

        ParkingLotInfoWithAddress? parkingLotInfo = null;
        if ((vehicle as Car) != null && TryAddVehicle(
            _carGarages, addr, (vehicle as Car)!, out parkingLotInfo))
        { return parkingLotInfo; }

        if ((vehicle as IBus) != null && TryAddVehicle(
            _busGarages, addr, (vehicle as IBus)!, out parkingLotInfo))
        { return parkingLotInfo; }

        if ((vehicle as IMotorcycle) != null && TryAddVehicle(
            _mcGarages, addr, (vehicle as IMotorcycle)!, out parkingLotInfo))
        { return parkingLotInfo; }

        if ((vehicle as IBoat) != null && TryAddVehicle(
            _boatHarbors, addr, (vehicle as IBoat)!, out parkingLotInfo))
        { return parkingLotInfo; }

        if ((vehicle as IAirplane) != null && TryAddVehicle(
            _airplaneHangars, addr, (vehicle as IAirplane)!, out parkingLotInfo))
        { return parkingLotInfo; }

        if ((vehicle as ECar) != null && TryAddVehicle(
            _eCarGarages, addr, (vehicle as ECar)!, out parkingLotInfo))
        { return parkingLotInfo; }

        if (TryAddVehicle(
            _multiGarages, addr, (vehicle as IVehicle)!, out parkingLotInfo))
        { return parkingLotInfo; }

        return parkingLotInfo;
    }

    private bool TryAddVehicle<VehicleType, GarageType>(
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

    public RegistrationNumber? RemoveVehicleFromGarage(
        string addr, 
        uint parkingLotId)
    {
        var selectedGarage = GetGarage(addr);
        if (selectedGarage == null) { return null; }

        if (TryRemoveVehicle<Car, IGarage<Car>>(
            _carGarages,
            addr,
            parkingLotId,
            out var regNumber))
        { if (regNumber != null) { return regNumber; } }

        return null;
    }

    private bool TryRemoveVehicle<VehicleType, GarageType>(
        IEnumerable<GarageType> garages,
        string address,
        uint parkingLotId,
        out RegistrationNumber? regNumber
    )
        where VehicleType : IVehicle
        where GarageType : IGarage<VehicleType>
    {
        regNumber = null;

        var garage = garages
            .Where(garage => garage.Address.Value == address)
            .FirstOrDefault();

        if (garage == null) { return false; }

        var result = garage.TryRemoveVehicle(
            parkingLotId,
            out var vehicle
        );

        regNumber = vehicle?.RegistrationNumber; 

        return result;
    }
}
