using Garage.Application.Constant;
using Garage.Model.Vehicle;
using System.Text;

namespace Garage.Application.View;


/// <summary>
/// A view class used to display the garage main menu
/// and read user input for the applications garage features.
/// </summary>
internal class GarageMenuView : IGarageMenuView
{
    public string PrintGarageMainMenu()
    {
        var garageMenu = $"""
        
        📋 Garage main menu:
                {GarageMenu.EXIT}) Quit application
                {GarageMenu.LIST_ALL_GARAGES}) List all garages
                {GarageMenu.LIST_ALL_VEHICLES}) List all vehicles in all garages
                {GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE}) List grouped vehicles by type in specified garage
                {GarageMenu.ADD_VEHICLE_TO_GARAGE}) Add vehicle to specified garage
                {GarageMenu.REMOVE_VEHICLE_FROM_GARAGE}) Remove vehicle from specified garage
                {GarageMenu.CREATE_GARAGE}) Create new garage
                {GarageMenu.SEARCH_VEHICLE_BY_REGNR}) Search after vehicle by registration number in all garages
                {GarageMenu.FILTER_VEHICLES}) Filter vehicles by [{GetCommonPropertiesKeys()}] from all garages
        ✏️ Select option ({GarageMenu.LIST_ALL_GARAGES}-{GarageMenu.FILTER_VEHICLES}) or {GarageMenu.EXIT} to quit: 
        """;
        Console.Write(garageMenu);
        return GetSelectedGarageMenuEntry(Console.ReadLine()?.Trim() ?? "");
    }

    private string GetCommonPropertiesKeys()
    {
        var text = new StringBuilder();
        var counter = 0;
        foreach (var key in Vehicle.GetPropertyDescriptionMap().Keys)
        {
            counter++;
            if (counter == Vehicle.GetPropertyDescriptionMap().Keys.Count)
            {
                text.Append(key.ToUpper());
            }
            else
            {
                text.Append(key.ToUpper() + ", ");
            }
        }
        return text.ToString();
    }

    private string GetSelectedGarageMenuEntry(
        string selectedMenu) => selectedMenu switch
    {
        GarageMenu.EXIT or
        GarageMenu.LIST_ALL_GARAGES or
        GarageMenu.LIST_ALL_VEHICLES or
        GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE or
        GarageMenu.ADD_VEHICLE_TO_GARAGE or
        GarageMenu.REMOVE_VEHICLE_FROM_GARAGE or
        GarageMenu.CREATE_GARAGE or
        GarageMenu.SEARCH_VEHICLE_BY_REGNR or
        GarageMenu.FILTER_VEHICLES => selectedMenu,
        _ => GarageMenu.DEFAULT
    };

    public void PrintCorruptedData(string selection)
    {
        Console.WriteLine($"\n\t⚠️ Could not handle selection '{selection}' due possible data corruption in the system.");
    }

    public void WriteStartListAllGaragesMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.LIST_ALL_GARAGES}) " +
            $"Stored garages in the system:");
    }

    public void WriteStartListAllVehiclesMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.LIST_ALL_VEHICLES}) " +
            $"Stored vehicles in the system:");
    }

    public void WriteStartGroupedVehiclesByTypeMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE}) List grouped vehicles by type in specified garage");
    }

    public void WriteStartAddVehicleMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.ADD_VEHICLE_TO_GARAGE}) Add vehicle to specified garage");
    }

    public void WriteRemoveAddVehicleMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.REMOVE_VEHICLE_FROM_GARAGE}) " +
            $"Remove vehicle from specified garage");
    }

    public void WriteStartCreateGarageMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.CREATE_GARAGE}) " +
            $"Create new garage");
    }

    public void WriteStartSearchVehicleByRegNrMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.SEARCH_VEHICLE_BY_REGNR}) " +
            $"Search after vehicle by registration number in all garages");
    }

    public void WriteStartFilterMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.FILTER_VEHICLES}) " +
            $"Enter property to filter search on (use ',' as separation if using multiple values): ");
    }

    public void PrintIncorrectMenuSelection(string selection)
    {
        Console.WriteLine($"\n⚠️ '{selection}' is not a valid menu selection.");
    }
}
