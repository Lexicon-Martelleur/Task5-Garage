using Garage.Model.Garage;
using Garage.Model.Repository;

namespace Garage.Model.Service;


public class GarageService(IGarageRepository repository) : IGarageService
{
    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles()
    {
        var garageKeeper = repository.GetGarageKeeper();
        var validatedGarageKeeper = ValidateGarages(garageKeeper);
        return validatedGarageKeeper.GetAllParkingLotsWithVehicles();
    }

    public IEnumerable<GarageInfo> GetAllGarages()
    {
        var garageKeeper = ValidateGarages(repository.GetGarageKeeper());
        return garageKeeper.GetAllGarages();
    }

    private GarageKeeper ValidateGarages(GarageKeeper garageKeeper)
    {
        if (!IsUniqueGarageAddresses(garageKeeper))
        {
            throw new InvalidGarageStateException("Address must be unique for each garage.");
        }
        if (!IsUniqueCarRegistrationNumbers(garageKeeper))
        {
            throw new InvalidGarageStateException("Car registration number must be unique for each garage.");
        }
        return garageKeeper;
    }

    private bool IsUniqueGarageAddresses(GarageKeeper garageKeeper)
    {
        var totalAddresses = garageKeeper.GetAllGarageAddresses();
        var uniqueAddresses = totalAddresses.ToHashSet();
        return totalAddresses.Count() == uniqueAddresses.Count;
    }

    private bool IsUniqueCarRegistrationNumbers(GarageKeeper garageKeeper)
    {
        var parkingLotsWithVehicles = garageKeeper.GetAllParkingLotsWithVehicles();
        var uniqueCars = parkingLotsWithVehicles
            .Select(lot => lot.vehicleRegNr)
            .ToHashSet();
        return parkingLotsWithVehicles.Count() == uniqueCars.Count;
    }

    public IEnumerable<ParkingLotInfo> GetGroupedVehiclesByType(string garageAddress)
    {
        var garageKeeper = ValidateGarages(repository.GetGarageKeeper());

        throw new NotImplementedException();
    }
}

