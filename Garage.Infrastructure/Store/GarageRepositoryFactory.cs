
using Garage.Model.Repository;

namespace Garage.Infrastructure.Store;

public class GarageRepositoryFactory : IGarageRepositoryFactory
{
    public IGarageRepository GetGarageRepository()
    {
        return new GarageInMemoryStore();
    }
}
