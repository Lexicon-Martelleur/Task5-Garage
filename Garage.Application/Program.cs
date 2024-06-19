using Garage.Application.Controller;

/// <summary>
/// Main method used to start a garage menu.
/// </summary>

IGarageControllerFactory factory = new GarageControllerFactory();
var garageMenuController = factory.CreateGarageMenuController();
garageMenuController.StartGarageMenu();
