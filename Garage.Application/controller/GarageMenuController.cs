using Garage.Application.Constant;
using Garage.Application.View;
using Garage.Model.ParkingLot;
using Garage.Model.Service;
using Garage.Model.Vehicle;

namespace Garage.Application.controller;

internal class GarageMenuController
{
    private bool _quitGarageMainMenu = false;

    private readonly Dictionary<string, Action<string>> _mainMenuActions;
    private readonly GarageMenuView _view;
    private readonly IGarageService _service;

    public GarageMenuController(GarageMenuView view, IGarageService service)
    {
        _view = view;
        _service = service;
        _mainMenuActions = new() 
        {
            { GarageMenu.EXIT, _ => HandleExit() },
            { GarageMenu.LIST_ALL_GARAGES, HandleListAllGarages },
            { GarageMenu.LIST_ALL_VEHICLES, HandleListAllVehicles },
            { GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE, HandleListGroupedVehiclesByType },
            { GarageMenu.ADD_VEHICLE_TO_GARAGE, HandleAddVehicleToGarage },
            { GarageMenu.REMOVE_VEHICLE_FROM_GARAGE, HandleRemoveVehicleFromGarage },
            { GarageMenu.CREATE_GARAGE, HandleCreateGarage },
            { GarageMenu.SEARCH_VEHICLE_BY_REGNR, HandleSearchVehicleByRegNr },
            { GarageMenu.FILTER_VEHICLES, HandleFilterVehicle },
        };
    }

    internal void StartGarageMainMenu()
    {
        do
        {
            HandleMainMenuSelection(_view.PrintGarageMainMenu());

        } while (!_quitGarageMainMenu);
    }

    private void HandleMainMenuSelection(string userInput)
    {
        if (_mainMenuActions.TryGetValue(userInput, out var MainMenuAction))
        {
            MainMenuAction(userInput);
        }
        else
        {
            HandleIncorrectMenuSelection(userInput);
        }
    }

    private void HandleExit()
    {
        _quitGarageMainMenu = true;
    }

    private void HandleListAllGarages(string menuSelection)
    {
        try {
            _view.PrintAllGarages(_service.GetAllGarages());
        }
        catch {
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListAllVehicles(string menuSelection)
    {
        try {
            var parkingLotInfos = _service.GetAllParkingLotsWithVehicles();
            _view.PrintAllParkingLotsWithVehicles(parkingLotInfos);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListGroupedVehiclesByType(string menuSelection)
    {
        try
        {
            if (EmptyString(out string address, _view.ReadGarageAddress)) { return; }
            var groupedVehicles = _service.GetGroupedVehiclesByVehicleType(address);
            _view.PrintGroupedVehicles(groupedVehicles, address);
        }
        catch
        {
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private bool EmptyString(out string value, Func<string> ReadFromUser)
    {
        return InvalidInput(
            out value,
            ReadFromUser,
            _view.WriteNotValidInput,
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
            if (EmptyString(out string address, _view.ReadGarageAddress) ||
                EmptyString(out string regNumber, _view.ReadVehicleRegNr) ||
                InvalidVehicleType(out string vehicleType))
            {
                return;
            }
            var result = _service.AddVehicleToGarage(
                address,
                regNumber,
                vehicleType,
                out ParkingLotInfoWithAddress? parkingLotInfo);
            if (result && parkingLotInfo != null)
            {
                _view.PrintVehicleAddedToGarage(
                    parkingLotInfo, regNumber, vehicleType);
            }
        }
        catch
        {
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private bool InvalidVehicleType(out string vehicleType)
    {
        return InvalidInput(
            out vehicleType,
            _view.ReadVehicleType,
            _view.WriteNotValidInput,
            (string value) => value.Equals(VehicleType.DEFAULT));
    }

    private void HandleRemoveVehicleFromGarage(string menuSelection)
    {
    }

    private void HandleCreateGarage(string menuSelection)
    {
    }

    private void HandleSearchVehicleByRegNr(string menuSelection)
    {
    }

    private void HandleFilterVehicle(string menuSelection)
    {
    }

    private void HandleIncorrectMenuSelection(string userInput)
    {
        _view.PrintIncorrectMenuSelection(userInput);
    }
}
