using Garage.Model.Garage;
using Garage.Model.Repository;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;


public class GarageService(IGarageRepository repository) : IGarageService
{
    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles()
    {
        var parkingLotInfo = repository.GetAllParkingLotsWithVehicles();
        if (!IsUniqueCarRegistrationNumbers(parkingLotInfo))
        {
            throw new InvalidGarageStateException("Car registration number must be unique for each garage.");
        }
        return parkingLotInfo;
    }

    public IEnumerable<GarageInfo> GetAllGarages()
    {
        var garages = repository.GetAllGarages();
        if (!IsUniqueGarageAddresses(garages))
        {
            throw new InvalidGarageStateException("Address must be unique for each garage.");
        }
        return garages;
    }

    private bool IsUniqueGarageAddresses(IEnumerable<GarageInfo> garages)
    {
        var uniqueAddresses = garages.ToHashSet();
        return garages.Count() == uniqueAddresses.Count;
    }

    private bool IsUniqueCarRegistrationNumbers(IEnumerable<ParkingLotInfo> parkingLotInfos)
    {
        var uniqueCars = parkingLotInfos
            .Select(lot => lot.vehicleRegNr)
            .ToHashSet();
        return parkingLotInfos.Count() == uniqueCars.Count;
    }

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress)
    {
        return repository.GetGroupedVehiclesByVehicleType(garageAddress);
    }
}

