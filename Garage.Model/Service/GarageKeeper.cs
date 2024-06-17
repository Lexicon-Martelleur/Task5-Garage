using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public class GarageKeeper
{
    private IEnumerable<IGarage<Car>> _carGarages = [];

    private IEnumerable<IGarage<IBus>> _busGarages = [];

    private IEnumerable<IGarage<IMotorcycle>> _mcGarages = [];

    private IEnumerable<IGarage<IBoat>> _boatHarbors = [];

    private IEnumerable<IGarage<IAirplane>> _airplaneHangars = [];

    private IEnumerable<IGarage<ECar>> _eCarGarages = [];

    private IEnumerable<IGarage<IVehicle>> _multiGarages = [];

    public IEnumerable<IGarage<Car>> CarGarages {
        get => _carGarages;
        init => _carGarages = value;
    }

    public IEnumerable<IGarage<IBus>> BusGarages
    {
        get => _busGarages;
        init => _busGarages = value;
    }

    public IEnumerable<IGarage<IMotorcycle>> MCGarages
    {
        get => _mcGarages;
        init => _mcGarages = value;
    }

    public IEnumerable<IGarage<IBoat>> BoatHarbors
    {
        get => _boatHarbors;
        init => _boatHarbors = value;
    }

    public IEnumerable<IGarage<IAirplane>> AirplaneHangars
    {
        get => _airplaneHangars;
        init => _airplaneHangars = value;
    }

    public IEnumerable<IGarage<ECar>> ECarGarages
    {
        get => _eCarGarages;
        init => _eCarGarages = value;
    }

    public IEnumerable<IGarage<IVehicle>> MultiGarages
    {
        get => _multiGarages;
        init => _multiGarages = value;
    }

    public IEnumerable<GarageInfo> GetAllGarages()
    {
        List<GarageInfo> garageInfoItems = [];
        garageInfoItems.AddRange(CarGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        garageInfoItems.AddRange(BusGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        garageInfoItems.AddRange(MCGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        garageInfoItems.AddRange(BoatHarbors.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        garageInfoItems.AddRange(AirplaneHangars.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        garageInfoItems.AddRange(ECarGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        garageInfoItems.AddRange(MultiGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.GarageDescription)));

        return garageInfoItems;
    }

    public IEnumerable<string> GetAllGarageAddresses()
    {
        List<string> totalAddresses = [];
        totalAddresses.AddRange(CarGarages.Select(garage => garage.Address));
        totalAddresses.AddRange(BusGarages.Select(garage => garage.Address));
        totalAddresses.AddRange(MCGarages.Select(garage => garage.Address));
        totalAddresses.AddRange(BoatHarbors.Select(garage => garage.Address));
        totalAddresses.AddRange(AirplaneHangars.Select(garage => garage.Address));
        totalAddresses.AddRange(ECarGarages.Select(garage => garage.Address));
        totalAddresses.AddRange(MultiGarages.Select(garage => garage.Address));
        return totalAddresses;
    }

    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles()
    {
        List<ParkingLotInfo> parkingLotsInfo = [];
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(CarGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(BusGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(MCGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(BoatHarbors));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(AirplaneHangars));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(ECarGarages));
        parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarages(MultiGarages));
        return parkingLotsInfo;
    }

    private List<ParkingLotInfo> GetParkingLotsInfoFromGarages<VehicleType>(
        IEnumerable<IGarage<VehicleType>> garages)
        where VehicleType : IVehicle
    {
        List<ParkingLotInfo> parkingLotsInfo = [];
        foreach (var garage in garages)
        {
            parkingLotsInfo.AddRange(GetParkingLotsInfoFromGarage<VehicleType>(
                garage
            ));
        }
        return parkingLotsInfo;
    }

    private List<ParkingLotInfo> GetParkingLotsInfoFromGarage<VehicleType>(
        IGarage<VehicleType> garage)
        where VehicleType : IVehicle
    {
        List<ParkingLotInfo> parkingLotsInfo = [];
        foreach (var lot in garage.ParkingLots)
        {
            if (lot.CurrentVehicle == null) { continue; }
            
            parkingLotsInfo.Add(new ParkingLotInfo(
                garage.Address,
                lot.ID,
                lot.CurrentVehicle.RegistrationNumber.value,
                garage.ParkingLotDescription,
                lot.CurrentVehicle.Description
            )); 
        }
        return parkingLotsInfo;
    }
}
