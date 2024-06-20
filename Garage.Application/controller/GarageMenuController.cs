using Garage.Application.Constant;
using Garage.Application.View;
using System.Diagnostics;

namespace Garage.Application.Controller;

/// <summary>
/// A controller class used to control data flow between
/// the user and the domain/model layer.
/// </summary>
internal class GarageMenuController : IGarageMenuController
{
    private bool _quitGarageMenu = false;
    private readonly Dictionary<string, Action<string>> _menuActionsMap;
    private readonly IGarageMenuView _view;
    private readonly IGarageSubMenuController _subMenuController;

    /// <summary>
    /// A constructor used to create an instance of this class.
    /// In constructor a menu action map is also created.   
    /// </summary>
    /// <param name="view">
    /// A view type of <see cref="IGarageMenuView'"/> used to 
    /// read and write information to and from the user
    /// </param>
    /// <param name="subMenuController">
    /// A controller type of <see cref="IGarageSubMenuController"/> used to 
    /// delegate controller logic to.
    /// </param>
    internal GarageMenuController(
        IGarageMenuView view,
        IGarageSubMenuController subMenuController)
    {
        _view = view;
        _subMenuController = subMenuController;
        _menuActionsMap = new()
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

    public void StartGarageMenu()
    {
        do { HandleMainMenuSelection(_view.PrintGarageMainMenu()); }
        while (!_quitGarageMenu);
    }

    private void HandleMainMenuSelection(string input)
    {
        if (_menuActionsMap.TryGetValue(input, out var MenuAction))
        {
            MenuAction(input);
        }
        else
        {
            HandleIncorrectMenuSelection(input);
        }
    }

    private void HandleExit()
    {
        _quitGarageMenu = true;
    }

    private void HandleListAllGarages(string menuSelection)
    {
        try
        {
            _view.WriteStartListAllGaragesMenu();
            _subMenuController.HandleListAllGarages();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListAllVehicles(string menuSelection)
    {
        try
        {
            _view.WriteStartListAllVehiclesMenu();
            _subMenuController.HandleListAllVehicles();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleListGroupedVehiclesByType(string menuSelection)
    {
        try
        {
            _view.WriteStartGroupedVehiclesByTypeMenu();
            _subMenuController.HandleListGroupedVehiclesByType();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleAddVehicleToGarage(string menuSelection)
    {
        try
        {
            _view.WriteStartAddVehicleMenu();
            _subMenuController.HandleAddVehicleToGarage();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleRemoveVehicleFromGarage(string menuSelection)
    {
        try
        {
            _view.WriteRemoveAddVehicleMenu();
            _subMenuController.HandleRemoveVehicleFromGarage();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleCreateGarage(string menuSelection)
    {
        try
        {
            _view.WriteStartCreateGarageMenu();
            _subMenuController.HandleCreateGarage();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleSearchVehicleByRegNr(string menuSelection)
    {
        try
        {
            _view.WriteStartSearchVehicleByRegNrMenu();
            _subMenuController.HandleSearchVehicleByRegNumber();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleFilterVehicle(string menuSelection)
    {
        try
        {
            _view.WriteStartFilterMenu();
            _subMenuController.HandleFilterVehicle();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _view.PrintCorruptedData(menuSelection);
        }
    }

    private void HandleIncorrectMenuSelection(string userInput)
    {
        _view.PrintIncorrectMenuSelection(userInput);
    }
}
