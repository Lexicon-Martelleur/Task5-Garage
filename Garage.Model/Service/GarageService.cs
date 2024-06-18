using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;


public class GarageService(IGarageRepository repository) : IGarageService
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

    public bool AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType,
        out ParkingLotInfoWithAddress? parkingLotInfo)
    {
        var vehicleFactory = new VehicleFactory();

        switch (vehicleType)
        {
            case VehicleType.CAR:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateGasolineCar(regNumber),
                    out parkingLotInfo);
            case VehicleType.BUS:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateBus(regNumber),
                    out parkingLotInfo);
            case VehicleType.MOTORCYCLE:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateMC(regNumber),
                    out parkingLotInfo);
            case VehicleType.BOAT:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateBoat(regNumber),
                    out parkingLotInfo);
            case VehicleType.AIRPLANE:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateAirplane(regNumber),
                    out parkingLotInfo);
            case VehicleType.E_CAR:
                return repository.AddVehicleToGarage(
                    address,
                    vehicleFactory.CreateECar(regNumber),
                    out parkingLotInfo);
            default:
                parkingLotInfo = null;
                return false;
        };
    }
}

