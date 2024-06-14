using Garage.Model.Service;

namespace Garage.Model.Repository;

public interface IGarageRepository
{
    public GarageHolder GetAllGarages();
}
