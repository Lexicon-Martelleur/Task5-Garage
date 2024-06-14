using Garage.Model.Repository;

namespace Garage.Infrastructure.Store;

public interface IGarageRepositoryFactory
{
    IGarageRepository GetGarageRepository();
}