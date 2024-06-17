using Garage.Application.Constant;
using Garage.Application.View;
using Garage.Model.Garage;
using Garage.Model.Service;

namespace Garage.Application.controller;

internal class GarageMenuController(GarageMenuView view, IGarageService service)
{
    private bool _quitGarageMainMenu = false;

    internal void StartGarageMainMenu()
    {
        do
        {
            HandleMainMenuSelection(view.PrintGarageMainMenu());

        } while (!_quitGarageMainMenu);
    }

    private void HandleMainMenuSelection(string userInput)
    {
       switch (userInput)
        {
            case GarageMenu.EXIT:
                HandleExit();
                break;
            case GarageMenu.LIST_ALL_GARAGES:
                HandleListAllGarages(GarageMenu.LIST_ALL_GARAGES);
                break;
            case GarageMenu.LIST_ALL_VEHICLES:
                HandleListAllVehicles(GarageMenu.LIST_ALL_VEHICLES);
                break;
            case GarageMenu.LIST_VEHICLES_INFO_IN_GARAGE:
                HandleListVehiclesInfoInGarage();
                break;
            case GarageMenu.ADD_VEHICLE_TO_GARAGE:
                HandleAddVehicleToGarage();
                break;
            case GarageMenu.REMOVE_VEHICLE_FROM_GARAGE:
                HandleRemoveVehicleFromGarage();
                break;
            case GarageMenu.CREATE_GARAGE:
                HandleCreateGarage();
                break;
            case GarageMenu.SEARCH_VEHICLE_BY_REGNR:
                HandleSearchVehicleByRegNr();
                break;
            case GarageMenu.FILTER_VEHICLES:
                HandleFilterVehicle();
                break;
            default:
                HandleIncorrectMenuSelection(userInput);
                break;
        }
    }

    private void HandleExit()
    {
        _quitGarageMainMenu = true;
    }

    private void HandleListAllGarages(string menuSelection)
    {
        try {
            view.PrintAllGarages(service.GetAllGarages());
        }
        catch {
            view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListAllVehicles(string menuSelection)
    {
        try {
            var parkingLotInfos = service.GetAllParkingLotsWithVehicles();
            view.PrintAllParkingLotsWithVehicles(parkingLotInfos);
        }
        catch
        {
            view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListVehiclesInfoInGarage()
    {
    }

    private void HandleAddVehicleToGarage()
    {
    }

    private void HandleRemoveVehicleFromGarage()
    {
    }

    private void HandleCreateGarage()
    {
    }

    private void HandleSearchVehicleByRegNr()
    {
    }

    private void HandleFilterVehicle()
    {
    }

    private void HandleIncorrectMenuSelection(string userInput)
    {
        view.PrintIncorrectMenuSelection(userInput);
    }
}
