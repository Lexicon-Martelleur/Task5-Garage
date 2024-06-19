namespace Garage.Application.Controller;

/// <summary>
/// An interface used to describe a IGarageControllerFactory
/// </summary>
internal interface IGarageControllerFactory
{
    IGarageMenuController CreateGarageMenuController();
}
