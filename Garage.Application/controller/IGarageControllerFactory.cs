namespace Garage.Application.Controller;

/// <summary>
/// An interface used to describe a GarageControllerFactory
/// </summary>
internal interface IGarageControllerFactory
{
    IGarageMenuController CreateGarageMenuController();
}
