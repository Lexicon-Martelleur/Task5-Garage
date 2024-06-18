using Garage.Application.Constant;
using Garage.Application.View;
using Garage.Model.ParkingLot;
using Garage.Model.Service;
using Garage.Model.Vehicle;

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
                HandleListAllGarages(userInput);
                break;
            case GarageMenu.LIST_ALL_VEHICLES:
                HandleListAllVehicles(userInput);
                break;
            case GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE:
                HandleListGroupedVehiclesByType(userInput);
                break;
            case GarageMenu.ADD_VEHICLE_TO_GARAGE:
                HandleAddVehicleToGarage(userInput);
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
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListGroupedVehiclesByType(string menuSelection)
    {
        try
        {
            if (EmptyString(out string address, view.ReadGarageAddress)) { return; }
            var groupedVehicles = service.GetGroupedVehiclesByVehicleType(address);
            view.PrintGroupedVehicles(groupedVehicles, address);
        }
        catch
        {
            view.PrintCorruptedData(menuSelection);
        }
    }

    private bool EmptyString(out string value, Func<string> ReadFromUser)
    {
        return InvalidInput(
            out value,
            ReadFromUser,
            view.WriteNotValidInput,
            (string value) => value.Equals(String.Empty));
    }

    private bool InvalidInput(
        out string value,
        Func<string> ReadFromUser,
        Action<string> WriteCorrectionToUser,
        Func<string, bool> Predicate)
    {
        value = ReadFromUser();
        if (Predicate(value))
        {
            WriteCorrectionToUser(value);
            return true;
        }
        return false;
    }

    private void HandleAddVehicleToGarage(string menuSelection)
    {
        try
        {
            if (EmptyString(out string address, view.ReadGarageAddress) ||
                EmptyString(out string regNumber, view.ReadVehicleRegNr) ||
                InvalidVehicleType(out string vehicleType))
            {
                return;
            }
            var result = service.AddVehicleToGarage(
                address,
                regNumber,
                vehicleType,
                out ParkingLotInfoWithAddress? parkingLotInfo);
            if (result && parkingLotInfo != null)
            {
                view.PrintVehicleAddedToGarage(
                    parkingLotInfo, regNumber, vehicleType);
            }
        }
        catch
        {
            view.PrintCorruptedData(menuSelection);
        }
    }

    private bool InvalidVehicleType(out string vehicleType)
    {
        return InvalidInput(
            out vehicleType,
            view.ReadVehicleType,
            view.WriteNotValidInput,
            (string value) => value.Equals(VehicleType.DEFAULT));
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
