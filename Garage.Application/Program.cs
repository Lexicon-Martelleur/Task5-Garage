using Garage.Application.controller;
using Garage.Application.View;
using Garage.Infrastructure.Store;
using Garage.Model.Service;

IGarageRepositoryFactory garageRepositoryFactory = new GarageRepositoryFactory();

IGarageService garageService = new GarageService(
    garageRepositoryFactory.GetGarageRepository());

var garageMenuView = new GarageMenuView();

var garageMenuController = new GarageMenuController(
    garageMenuView,
    garageService);

garageMenuController.Start();
