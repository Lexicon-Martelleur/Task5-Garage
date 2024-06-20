using Garage.Application;
using Garage.Application.Controller;

/// <summary>
/// Main method used to start a garage menu.
/// </summary>

#if DEBUG
DebugUtility.StartDebug();
#endif
Console.OutputEncoding = System.Text.Encoding.UTF8;

var garageControllerFactory = new GarageControllerFactory();
var garageMenuController = garageControllerFactory.CreateGarageMenuController();
garageMenuController.StartGarageMenu();
