using Garage.Application.Constant;
using Garage.Model.Garage;
using Garage.Model.Service;
using Garage.Model.Vehicle;

namespace Garage.Application.View;

internal class GarageMenuView
{
    public string PrintGarageMainMenu()
    {
        var garageMenu = $"""
        
        Garage main menu:
                {GarageMenu.EXIT}) Quit application
                {GarageMenu.LIST_ALL_GARAGES}) List all garages
                {GarageMenu.LIST_ALL_VEHICLES}) List all vehicles in all garages
                {GarageMenu.LIST_VEHICLES_INFO_IN_GARAGE}) List vehicles types and number in specified garage
                {GarageMenu.ADD_VEHICLE_TO_GARAGE}) Add vehicle from specified garage
                {GarageMenu.REMOVE_VEHICLE_FROM_GARAGE}) Remove vehicle from specified garage
                {GarageMenu.CREATE_GARAGE}) Search after vehicle registration number in all garages.
                {GarageMenu.SEARCH_VEHICLE_BY_REGNR}) Search after vehicle registration number in all garages.
                {GarageMenu.FILTER_VEHICLES}) Filter vehicles by (<common properties>) in all garages
        Select option ({GarageMenu.LIST_ALL_GARAGES}-{GarageMenu.FILTER_VEHICLES}) or {GarageMenu.EXIT} to quit: 
        """;
        Console.Write(garageMenu);
        return GetSelectedGarageMenuEntry(Console.ReadLine() ?? "");
    }

    private string GetSelectedGarageMenuEntry(string selectedMenu) => selectedMenu switch
    {
        GarageMenu.EXIT or
        GarageMenu.LIST_ALL_GARAGES or
        GarageMenu.LIST_ALL_VEHICLES or
        GarageMenu.LIST_VEHICLES_INFO_IN_GARAGE or
        GarageMenu.ADD_VEHICLE_TO_GARAGE or
        GarageMenu.REMOVE_VEHICLE_FROM_GARAGE or
        GarageMenu.CREATE_GARAGE or
        GarageMenu.SEARCH_VEHICLE_BY_REGNR or
        GarageMenu.FILTER_VEHICLES => selectedMenu,
        _ => GarageMenu.DEFAULT
    };

    internal void PrintAllGarages(IEnumerable<GarageInfo> garages)
    {
        Console.WriteLine("\nStored garages in the system:");
        garages.ToList().ForEach(i => Console.WriteLine(GetGarageInfo(i)));
    }

    private string GetGarageInfo(GarageInfo info)
    {
        return $"\t➡️ Garage [{info.address}]: " +
            $"{info.description} with capacity of {info.capacity} vehicles.";
    }

    internal void PrintIncorrectMenuSelection(string selection)
    {
        Console.WriteLine($"\n⚠️ '{selection}' is not a valid menu selection.");
    }

    internal void PrintAllParkingLotsWithVehicles(IEnumerable<ParkingLotInfo> parkingLotsInfos)
    {
        Console.WriteLine("\nStored vehicles in the system:");
        parkingLotsInfos.ToList().ForEach(i => Console.WriteLine(GetParkingLotInfo(i)));
    }

    private string GetParkingLotInfo(ParkingLotInfo info)
    {
        return $"\t➡️ Car [{info.regNr}]: " +
            $"Parked in garage '{info.garageAddress}' at parking lot '{info.ParkinLotId}'";
    }
}
