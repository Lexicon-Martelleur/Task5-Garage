using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

/// <summary>
/// A Service class implementing <see cref="IGarageService"/> used
/// to handle domain garage logic.
/// </summary>
/// <param name="repository">
/// A repository of type <see cref="IGarageRepository"/> used to abstract garage storage
/// </param>
/// <param name="vehicleFactory">
/// A factory used to create vehicles of different types
/// </param>
public class GarageService(
    IGarageRepository repository,
    VehicleFactory vehicleFactory
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

    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles(
        Dictionary<string, string[]> filterMap)
    {
        var parkingLotInfo = repository.GetAllParkingLotsWithVehicles(filterMap);
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
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        Dictionary<
            string,
            Func<string, string, string, Dictionary< string, string>, ParkingLotInfoWithAddress ?>
        > carFactoryMap = new()
        {
            { VehicleTypeKeeper.AIRPLANE.ID, AddAirplaneToGarage },
            { VehicleTypeKeeper.BOAT.ID, AddBoatToGarage },
            { VehicleTypeKeeper.BUS.ID, AddBusToGarage },
            { VehicleTypeKeeper.CAR.ID, AddGasolineCarToGarage },
            { VehicleTypeKeeper.E_CAR.ID, AddECarToGarage },
            { VehicleTypeKeeper.MOTORCYCLE.ID, AddMCToGarage }
        };

        if (carFactoryMap.TryGetValue(vehicleType, out var carFactory))
        {
            return carFactory(addr, regNumber, vehicleType, creationMap);
        }
        return null;
    }

    private ParkingLotInfoWithAddress? AddAirplaneToGarage(
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        return repository.AddVehicleToGarage(addr, vehicleFactory.CreateAirplane(
            regNumber, creationMap
        ));
    }

    private ParkingLotInfoWithAddress? AddBoatToGarage(
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        return repository.AddVehicleToGarage(addr, vehicleFactory.CreateBoat(
            regNumber, creationMap
        ));
    }

    private ParkingLotInfoWithAddress? AddBusToGarage(
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        return repository.AddVehicleToGarage(addr, vehicleFactory.CreateBus(
            regNumber, creationMap
        ));
    }

    private ParkingLotInfoWithAddress? AddGasolineCarToGarage(
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        return repository.AddVehicleToGarage(addr, vehicleFactory.CreateGasolineCar(
            regNumber, creationMap
        ));
    }

    private ParkingLotInfoWithAddress? AddECarToGarage(
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        return repository.AddVehicleToGarage(addr, vehicleFactory.CreateECar(
            regNumber, creationMap
        ));
    }

    private ParkingLotInfoWithAddress? AddMCToGarage(
        string addr,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap)
    {
        return repository.AddVehicleToGarage(addr, vehicleFactory.CreateMC(
            regNumber, creationMap
        ));
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
