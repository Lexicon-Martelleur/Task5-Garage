
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Repository;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

// TODO! Use repository interface to get garage data.
// TODO! Use new type GarageHolder instead of specific garage ???
public class GarageService(IGarageRepository repository) : IGarageService
{
    public GarageHolder GetAllGarages()
    {
        return repository.GetAllGarages();
    }
}

