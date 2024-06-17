using Garage.Model.Garage;
using Garage.Model.Repository;

namespace Garage.Model.Service;


public class GarageService(IGarageRepository repository) : IGarageService
{
    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles()
    {
        var garageKepper = ValidateGarages(repository.GetGarageKeeper());
        // TODO validate unique reg numbers;
        return garageKepper.GetAllParkingLotsWithVehicles();
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
        return garageKeeper;
    }

    private bool IsUniqueGarageAddresses(GarageKeeper garageKeeper)
    {
        var totalAddresses = garageKeeper.GetAllGarageAddresses();
        var uniqueAddresses = totalAddresses.ToHashSet();
        return totalAddresses.Count() == uniqueAddresses.Count;
    }
}

