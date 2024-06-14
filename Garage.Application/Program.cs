
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Service;
using Garage.Model.Vehicle;

var universalGarageFactory = new UniversalGarageFactory();
var univarsalGarage = universalGarageFactory.CreateGarage(20);
var universalGarageService = new GarageService<
    IParkingLot<IVehicle>,
    IVehicle
>(univarsalGarage);


var carGarageFactory = new CarGarageFactory();
var carGarage = carGarageFactory.CreateGarage(20);
var carGarageService = new GarageService<
    CarParkingLot,
    ICar
>(carGarage);


var eCarGarageFactory = new ECarGarageFactory();
var eCarGarage = eCarGarageFactory.CreateGarage(20);
var eCarGarageService = new GarageService<
    ECarParkingLot,
    ECar
>(eCarGarage);
