using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public class GarageService(
    IGarageRepository repository
) : IGarageService
{
    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles()
    {
        var parkingLotInfo = repository.GetAllParkingLotsWithVehicles();
        if (!IsUniqueCarRegistrationNumbers(parkingLotInfo))
        {
            throw new InvalidGarageStateException("Registration number must be unique for each vehicle.");
        }
        return parkingLotInfo;
    }

    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages()
    {
        var garages = repository.GetAllGarages();
        if (!IsUniqueGarageAddresses(garages))
        {
            throw new InvalidGarageStateException("Address must be unique for each garage.");
        }
        return garages;
    }

    private bool IsUniqueGarageAddresses(IEnumerable<GarageInfoWithVehicleTypeName> garages)
    {
        var uniqueAddresses = garages.ToHashSet();
        return garages.Count() == uniqueAddresses.Count;
    }

    private bool IsUniqueCarRegistrationNumbers(
        IEnumerable<ParkingLotInfoWithAddress> parkingLotInfos)
    {
        var uniqueCars = parkingLotInfos
            .Select(lot => lot.ParkingLotInfo.VehicleRegistrationNumber)
            .ToHashSet();

        return parkingLotInfos.Count() == uniqueCars.Count;
    }

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress)
    {
        return repository.GetGroupedVehiclesByVehicleType(new Address(garageAddress));
    }

    public IGarageInfo? GetGarage(string address)
    {
        return repository.GetGarage(address);
    }

    public ParkingLotInfoWithAddress? AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType)
    {
        // TODO ! Move creation of vehicle to constructor.
        var vehicleFactory = new VehicleFactory();

        switch (vehicleType)
        {
            case VehicleTypeKeeper.CAR:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateGasolineCar(regNumber));
            case VehicleTypeKeeper.BUS:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateBus(regNumber));
            case VehicleTypeKeeper.MOTORCYCLE:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateMC(regNumber));
            case VehicleTypeKeeper.BOAT:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateBoat(regNumber));
            case VehicleTypeKeeper.AIRPLANE:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateAirplane(regNumber));
            case VehicleTypeKeeper.E_CAR:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateECar(regNumber));
            default:
                return null;
        };
    }

    public RegistrationNumber? RemoveVehicleFromGarage(string addr, uint parkingLotId)
    {
        return repository.RemoveVehicleFromGarage(addr, parkingLotId);
    }

    public IGarageInfo? CreateGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        Dictionary<
            string,
            Func<string, uint, GarageDescriptionItem, IGarageInfo?>
        > garageFactoryMap = new() 
        {
            { GarageDescriptionKeeper.AIRPLANE.ID, StoreAirplaneHangar },
            { GarageDescriptionKeeper.BOAT.ID, StoreBoatHarbor },
            { GarageDescriptionKeeper.BUS.ID, StoreBusGarage },
            { GarageDescriptionKeeper.CAR.ID, StoreGeneralCarGarage },
            { GarageDescriptionKeeper.CAR_NO_ELECTRICAL_PARKING_LOTS.ID, StoreCarGarage },
            { GarageDescriptionKeeper.E_CAR.ID, StoreECarGarage },
            { GarageDescriptionKeeper.MC.ID, StoreMCGarage },
            { GarageDescriptionKeeper.MULTI.ID, StoreMultiGarage }
        };

        if (garageFactoryMap.TryGetValue(description.ID, out var garageFactory))
        {
            return garageFactory(addr, capacity, description);
        }

        return null;
    }

    private IGarageInfo? StoreAirplaneHangar(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<IAirplane>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreBoatHarbor(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<IBoat>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreBusGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<IBus>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreGeneralCarGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<ICar>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreCarGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<Car>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreECarGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<ECar>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreMCGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<IMotorcycle>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    private IGarageInfo? StoreMultiGarage(
        string addr, uint capacity, GarageDescriptionItem description)
    {
        var garageFactory = new GarageFactory<IVehicle>();
        var garage = garageFactory.CreateGarage(
            capacity,
            new Address(addr),
            description
        );
        var resultStoredGarage = repository.StoreGarage(garage);
        return resultStoredGarage ? garage : null;
    }

    public ParkingLotInfoWithAddress? FindVehicleInAllGarages(string regNumber)
    {
        return repository.FindVehicleInAllGarages(regNumber);
    }
}
