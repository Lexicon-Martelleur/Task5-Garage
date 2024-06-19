using Garage.Application.Constant;

namespace Garage.Application.View;


// TODO! Remove empty postfix string spaces in input here or in controller.

/// <summary>
/// A view class used to display the garage main menu
/// and read user input for the applications garage features.
/// </summary>
internal class GarageMenuView
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
                {GarageMenu.FILTER_VEHICLES}) Filter vehicles by (<common properties>) in all garages
        ✏️ Select option ({GarageMenu.LIST_ALL_GARAGES}-{GarageMenu.FILTER_VEHICLES}) or {GarageMenu.EXIT} to quit: 
        """;
        Console.Write(garageMenu);
        return GetSelectedGarageMenuEntry(Console.ReadLine() ?? "");
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

    internal void PrintCorruptedData(string selection)
    {
        Console.WriteLine($"\n\t⚠️ Could not handle selection '{selection}' due possible data corruption in the system.");
    }

    internal void WriteStartListAllGaragesMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.LIST_ALL_GARAGES}) " +
            $"Stored garages in the system:");
    }

    internal void WriteStartListAllVehiclesMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.LIST_ALL_VEHICLES}) " +
            $"Stored vehicles in the system:");
    }

    internal void WriteStartGroupedVehiclesByTypeMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE}) List grouped vehicles by type in specified garage");
    }

    internal void WriteStartAddVehicleMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.ADD_VEHICLE_TO_GARAGE}) Add vehicle to specified garage");
    }

    internal void WriteRemoveAddVehicleMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.REMOVE_VEHICLE_FROM_GARAGE}) " +
            $"Remove vehicle from specified garage");
    }

    internal void WriteStartCreateGarageMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.CREATE_GARAGE}) " +
            $"Create new garage");
    }

    internal void WriteStartSearchVehicleByRegNrMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.SEARCH_VEHICLE_BY_REGNR}) " +
            $"Search after vehicle by registration number in all garages");
    }

    internal void WriteStartFilterMenu()
    {
        Console.WriteLine($"\nℹ️ Menu {GarageMenu.FILTER_VEHICLES}) " +
            $"Enter property to filter search on: ");
    }

    internal void PrintIncorrectMenuSelection(string selection)
    {
        Console.WriteLine($"\n⚠️ '{selection}' is not a valid menu selection.");
    }
}
