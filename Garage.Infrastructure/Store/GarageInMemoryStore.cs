using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;
using System.Collections;

namespace Garage.Infrastructure.Store;

/// <summary>
/// A class used to create, read, update, and delete garage data.
/// </summary>
public class GarageInMemoryStore : IGarageRepository
{

    private List<IGarage<Car>> _carGarages = [];
    private List<IGarage<ICar>> _multiCarGarages = [];
    private List<IGarage<IBus>> _busGarages = [];
    private List<IGarage<IMotorcycle>> _mcGarages = [];
    private List<IGarage<IBoat>> _boatHarbors = [];
    private List<IGarage<IAirplane>> _airplaneHangars = [];
    private List<IGarage<ECar>> _eCarGarages = [];
    private List<IGarage<IVehicle>> _multiGarages = [];

    public GarageInMemoryStore()
    {
        _busGarages.Clear();
        var garages = GarageInMemoryPopulator.CreateGarages();
        _carGarages = garages.CarGarages;
        _multiCarGarages = garages.MultiCarGarages;
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

        var multiCarGarage = _multiCarGarages
            .Where(garage => garage.Address == garageAddress)
            .FirstOrDefault();
        if (multiCarGarage != null) { return multiCarGarage.GroupVehiclesByVehicleType(); }

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

        garageInfoItems.AddRange(_multiCarGarages.Select(
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
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_carGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_multiCarGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_busGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_mcGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_boatHarbors));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_airplaneHangars));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_eCarGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_multiGarages));
        return parkingLotsInfo;
    }

    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles(
        Dictionary<string, string[]> filterMap)
    {
        List<ParkingLotInfoWithAddress> parkingLotsInfo = [];
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_carGarages, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_multiCarGarages, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_busGarages, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_mcGarages, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_boatHarbors, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_airplaneHangars, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_eCarGarages, filterMap));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromAllGarages(_multiGarages, filterMap));
        return parkingLotsInfo;
    }

    private IEnumerable<ParkingLotInfoWithAddress> GetParkingLotsInfoFromAllGarages<VehicleType>(
        IEnumerable<IGarage<VehicleType>> garages,
        Dictionary<string, string[]>? filterMap = null)
        where VehicleType : IVehicle
    {
        List<ParkingLotInfoWithAddress> parkingLotsInfo = [];
        foreach (var garage in garages)
        {
            parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarage(
                garage, filterMap
            ));
        }
        return parkingLotsInfo;
    }

    private IEnumerable<ParkingLotInfoWithAddress> GetParkingLotsInfoFromGarage<VehicleType>(
        IGarage<VehicleType> garage,
        Dictionary<string, string[]>? filterMap)
        where VehicleType : IVehicle
    {
        return garage.ParkingLots
            .Where(lot => lot.CurrentVehicle != null)
            .Where(lot =>
            {
                if (filterMap == null) {  return true; }
                return CheckFilterMap(lot, filterMap);
            })
            .Select(lot => new ParkingLotInfoWithAddress(garage.Address, lot));
    }

    private bool CheckFilterMap<VehicleType>(
        IParkingLot<VehicleType> lot,
        Dictionary<string, string[]> filterMap)
        where VehicleType : IVehicle
    {
        foreach (var key in filterMap.Keys)
        {
            if (key == VehicleUtility.ColorKey)
            {
                if (!filterMap[key].Contains(lot.CurrentVehicle?.Color))
                {
                    return false;
                }
            }
            else if (key == VehicleUtility.PowerSourceKey)
            {
                if (!filterMap[key].Contains(lot.CurrentVehicle?.PowerSource))
                {
                    return false;
                }
            }
            else if (key == VehicleUtility.VehicleTypeKey)
            {
                if (!filterMap[key].Contains(lot.CurrentVehicle?.Type.ToUpper()))
                {
                    return false;
                }
            }
            else if (key == VehicleUtility.VehicleWeightKey)
            {
                if (uint.TryParse(filterMap[key][0], out var result) &&
                    result != lot.CurrentVehicle?.Weight)
                {
                    return false;
                }
            }
            else if (key == VehicleUtility.VehicleDimensionKey)
            {
                if (uint.TryParse(filterMap[key][0], out var X) &&
                    uint.TryParse(filterMap[key][0], out var Y) &&
                    uint.TryParse(filterMap[key][0], out var Z))
                {
                    return new Dimension(X, Y, Z) == lot.CurrentVehicle?.Dimension;
                }
            }
        }
        return true;
    }

    public IGarageInfo? GetGarage(string addr)
    {
        var carGarage = _carGarages
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if ( carGarage != null ) { return carGarage; }

        var multiCarGarage = _multiCarGarages
            .Where(garage => garage.Address.Value == addr)
            .FirstOrDefault();
        if (multiCarGarage != null) { return multiCarGarage; }

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
        if (vehicle is Car car && TryAddVehicle(
            _carGarages, addr, car, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is ICar multiCar && TryAddVehicle(
            _multiCarGarages, addr, multiCar, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is IBus bus && TryAddVehicle(
            _busGarages, addr, bus, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is IMotorcycle mc && TryAddVehicle(
            _mcGarages, addr, mc, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is IBoat boat && TryAddVehicle(
            _boatHarbors, addr, boat, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is IAirplane airplane && TryAddVehicle(
            _airplaneHangars, addr, airplane, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is ECar eCar && TryAddVehicle(
            _eCarGarages, addr, eCar, out parkingLotInfo))
        { return parkingLotInfo; }

        if (vehicle is IVehicle multiVehicle && TryAddVehicle(
            _multiGarages, addr, multiVehicle, out parkingLotInfo))
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

        if (TryRemoveVehicle<ICar, IGarage<ICar>>(
            _multiCarGarages,
            addr,
            parkingLotId,
            out regNumber))
        { if (regNumber != null) { return regNumber; } }

        if (TryRemoveVehicle<IBus, IGarage<IBus>>(
            _busGarages,
            addr,
            parkingLotId,
            out regNumber))
        { if (regNumber != null) { return regNumber; } }

        if (TryRemoveVehicle<IMotorcycle, IGarage<IMotorcycle>>(
            _mcGarages,
            addr,
            parkingLotId,
            out regNumber))
        { if (regNumber != null) { return regNumber; } }

        if (TryRemoveVehicle<IBoat, IGarage<IBoat>>(
            _boatHarbors,
            addr,
            parkingLotId,
            out regNumber))
        { if (regNumber != null) { return regNumber; } }

        if (TryRemoveVehicle<IAirplane, IGarage<IAirplane>>(
            _airplaneHangars,
            addr,
            parkingLotId,
            out regNumber))
        { if (regNumber != null) { return regNumber; } }

        if (TryRemoveVehicle<ECar, IGarage<ECar>>(
            _eCarGarages,
            addr,
            parkingLotId,
            out regNumber))
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

    
    public bool StoreGarage<VehicleType>(IGarage<VehicleType> garage)
        where VehicleType : IVehicle
    {
        if (garage is IGarage<IAirplane> airplaneHangar)
        {
            var updatedGarages = _airplaneHangars.ToList();
            updatedGarages.Add(airplaneHangar);
            _airplaneHangars = updatedGarages;
            return true;
        }

        if (garage is IGarage<IBoat> boatHarbor)
        {
            var updatedGarages = _boatHarbors.ToList();
            updatedGarages.Add(boatHarbor);
            _boatHarbors = updatedGarages;
            return true;
        }

        if (garage is IGarage<IBus> busGarage)
        {
            var updatedGarages = _busGarages.ToList();
            updatedGarages.Add(busGarage);
            _busGarages = updatedGarages;
            return true;
        }

        if (garage is IGarage<ICar> multiCarGarage)
        {
            var updatedGarages = _multiCarGarages.ToList();
            updatedGarages.Add(multiCarGarage);
            _multiCarGarages = updatedGarages;
            return true;
        }

        if (garage is IGarage<Car> carGarage)
        {
            var updatedGarages = _carGarages.ToList();
            updatedGarages.Add(carGarage);
            _carGarages = updatedGarages;
            return true;
        }

        if (garage is IGarage<IMotorcycle> mcGarage)
        {
            var updatedGarages = _mcGarages.ToList();
            updatedGarages.Add(mcGarage);
            _mcGarages = updatedGarages;
            return true;
        }

        if (garage is IGarage<ECar> eCarGarage)
        {
            var updatedGarages = _eCarGarages.ToList();
            updatedGarages.Add(eCarGarage);
            _eCarGarages = updatedGarages;
            return true;
        }

        if (garage is IGarage<IVehicle> multiGarage)
        {
            var updatedGarages = _multiGarages.ToList();
            updatedGarages.Add(multiGarage);
            _multiGarages = updatedGarages;
            return true;
        }
        return false;
    }

    public ParkingLotInfoWithAddress? FindVehicleInAllGarages(string regNumber)
    {
        var infoFromAirplaneHangars = _airplaneHangars
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromAirplaneHangars != null) { return infoFromAirplaneHangars; }

        var infoFromBoatHarbors = _boatHarbors
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromBoatHarbors != null) { return infoFromBoatHarbors; }

        var infoFromBusGarages = _busGarages
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromBusGarages != null) { return infoFromBusGarages; }

        var infoFromCarGarages = _carGarages
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromCarGarages != null) { return infoFromCarGarages; }

        var infoFromMultiCarGarages = _multiCarGarages
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromMultiCarGarages != null) { return infoFromMultiCarGarages; }

        var infoFromECarGarages = _eCarGarages
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromECarGarages != null) { return infoFromECarGarages; }

        var infoFromMCGarages = _mcGarages
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromMCGarages != null) { return infoFromMCGarages; }

        var infoFromMultiGarages = _multiGarages
            .Where(garage => garage.GetParkingLotWithVehicle(regNumber) != null)
            .Select(garage => new ParkingLotInfoWithAddress(
                garage.Address, garage.GetParkingLotWithVehicle(regNumber)!))
            .FirstOrDefault();
        if (infoFromMultiGarages != null) { return infoFromMultiGarages; }

        return null;
    }
}
