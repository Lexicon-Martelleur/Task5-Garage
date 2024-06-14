
using Garage.Model.Garage;
using Garage.Model.Service;
using Garage.Model.Vehicle;

var universalGarageFactory = new GarageFactory<IVehicle>();
var univarsalGarage = universalGarageFactory.CreateGarage(20);
var universalGarageService = new GarageService<IVehicle>(univarsalGarage);


var carGarageFactory = new GarageFactory<ICar>();
var carGarage = carGarageFactory.CreateGarage(20);
var carGarageService = new GarageService<ICar>(carGarage);


var eCarGarageFactory = new GarageFactory<ECar>();
var eCarGarage = eCarGarageFactory.CreateGarage(20);
var eCarGarageService = new GarageService<ECar>(eCarGarage);
