using Garage.Application.View;
using Garage.Infrastructure.Store;
using Garage.Model.Service;
using Garage.Model.Vehicle;

namespace Garage.Application.Controller;

/// <summary>
/// A factory class used to create a type of <see cref="IGarageControllerFactory"/>
/// </summary>
internal class GarageControllerFactory : IGarageControllerFactory
{
    public IGarageMenuController CreateGarageMenuController()
    {
        IGarageSubMenuController subMenuController = CreateGarageSubMenuController();
        IGarageMenuView garageMenuView = new GarageMenuView();
        return new GarageMenuController(
            garageMenuView,
            subMenuController);
    }

    private IGarageSubMenuController CreateGarageSubMenuController()
    {
        IGarageRepositoryFactory garageRepositoryFactory = new GarageRepositoryFactory();

        VehicleFactory vehicleFactory = new VehicleFactory();

        IGarageService garageService = new GarageService(
            garageRepositoryFactory.GetGarageRepository(),
            vehicleFactory);

        IGarageSubMenuView garageSubMenuView = new GarageSubMenuView();
        return new GarageSubMenuController(
            garageSubMenuView,
            garageService);
    }
}
