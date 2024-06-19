using Garage.Application.Controller;
using Garage.Application.View;
using Garage.Infrastructure.Store;
using Garage.Model.Service;
using Garage.Model.Vehicle;

IGarageRepositoryFactory garageRepositoryFactory = new GarageRepositoryFactory();

VehicleFactory vehicleFactory = new VehicleFactory();

IGarageService garageService = new GarageService(
    garageRepositoryFactory.GetGarageRepository(),
    vehicleFactory);


var garageSubMenuView = new GarageSubMenuView();
var subMenuController = new GarageSubMenuController(garageSubMenuView, garageService);

var garageMenuView = new GarageMenuView();
var garageMenuController = new GarageMenuController(
    garageMenuView,
    subMenuController);

garageMenuController.StartGarageMenu();
