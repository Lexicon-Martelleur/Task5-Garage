﻿using Garage.Application.Constant;
using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
using System.Security.Cryptography;

namespace Garage.Application.View;


// TODO Remove empty postfix string spaces.
internal class GarageMenuView
{
    public string PrintGarageMainMenu()
    {
        var garageMenu = $"""
        
        📋 Garage main menu:
                {GarageMenu.EXIT}) Quit application
                {GarageMenu.LIST_ALL_GARAGES}) List all garages
                {GarageMenu.LIST_ALL_VEHICLES}) List all vehicles in all garages
                {GarageMenu.LIST_GROUPED_VEHICLES_BY_VEHICLE_TYPE}) List grouped vehicles by type
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

    internal void PrintAllGarages(IEnumerable<GarageInfoWithVehicleTypeName> garages)
    {
        Console.WriteLine("\nℹ️ Stored garages in the system:");
        garages.ToList().ForEach(i => Console.WriteLine(GetGarageInfo(i)));
    }

    private string GetGarageInfo(GarageInfoWithVehicleTypeName garage)
    {
        return $"\t➡️ Garage [{garage.GetAddress()}]: " +
            $"{garage.GetDescription()} " +
            $"with capacity of {garage.GetCapacity()} vehicles";
    }

    internal void PrintIncorrectMenuSelection(string selection)
    {
        Console.WriteLine($"\n⚠️ '{selection}' is not a valid menu selection.");
    }

    internal void PrintAllParkingLotsWithVehicles(
        IEnumerable<ParkingLotInfoWithAddress> parkingLotsInfos)
    {
        Console.WriteLine("\nℹ️ Stored vehicles in the system:");
        parkingLotsInfos.ToList().ForEach(i => Console.WriteLine(GetParkingLotInfo(i)));
    }

    private string GetParkingLotInfo(ParkingLotInfoWithAddress lot)
    {
        return $"\t➡️ {lot.GetVehicleType()} " +
            $"[{lot.GetVehicleRegistrationNumber()}]: " +
            $"Parked at '{lot.GetAddress()}' in lot ID '{lot.GetParkingLotID()}'";
    }

    internal void PrintCorruptedData(string selection)
    {
        Console.WriteLine($"\n⚠️ Could not handle selection '{selection}' due possible data corruption in the system.");
    }

    internal string ReadGarageAddress()
    {
        Console.Write("\n✏️ Enter a valid garage address: ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal void PrintNoGarageFoundForAddress(string address)
    {
        Console.WriteLine($"\n⚠️ No garage exist in the system with address: '{address}'");
    }

    internal void PrintGroupedVehicles(
        IEnumerable<GroupedVehicle>? groupedVehicles,
        string address)
    {
        if (groupedVehicles == null)
        {
            PrintNoGarageFoundForAddress(address);
        }
        else
        {
            PrintGroupedVehiclesEntries(groupedVehicles, address);
        }
    }

    private void PrintGroupedVehiclesEntries(
        IEnumerable<GroupedVehicle> groupedVehiclesEntries,
        string address)
    {
        if (groupedVehiclesEntries.Count() == 0) {
            Console.WriteLine($"\nℹ️ Garage is empty");
        }
        else
        {
            Console.WriteLine($"\nℹ️ Garage [{address}] current status:");
            foreach (var item in groupedVehiclesEntries)
            {
                Console.WriteLine($"\t➡️ {item.Count} {item.VehicleType} entries");
            }
        }
    }

    internal void WriteNotValidInput(string input)
    {
        if (input == String.Empty)
        {
            Console.WriteLine("\n⚠️ An empty input is not valid");
        }
        else
        {
            Console.WriteLine($"\n⚠️ Input {input} is not valid");
        }
    }

    internal string ReadVehicleRegNr()
    {
        Console.Write("\n✏️ Enter vehicle registration number: ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal string ReadVehicleType()
    {
        var listOfVehicleTypes = $"""

        📋 Vehicles types:
                {VehicleTypeKeeper.AIRPLANE}) Airplane
                {VehicleTypeKeeper.BOAT}) Boat
                {VehicleTypeKeeper.BUS}) Bus
                {VehicleTypeKeeper.CAR}) Car
                {VehicleTypeKeeper.E_CAR}) E-car
                {VehicleTypeKeeper.MOTORCYCLE}) Motorcycle
        """;

        Console.WriteLine(listOfVehicleTypes);
        Console.Write("\n✏️ Select vehicle type: ");
        return GetSelectedVehicleType(Console.ReadLine() ?? String.Empty);
    }

    private string GetSelectedVehicleType(
        string selectedVehicleType) => selectedVehicleType switch
    {
        VehicleTypeKeeper.AIRPLANE or
        VehicleTypeKeeper.BOAT or
        VehicleTypeKeeper.BUS or
        VehicleTypeKeeper.CAR or
        VehicleTypeKeeper.E_CAR or
        VehicleTypeKeeper.MOTORCYCLE => selectedVehicleType,
        _ => VehicleTypeKeeper.DEFAULT
    };

    internal void PrintVehicleAddedToGarage(
        ParkingLotInfoWithAddress lot,
        string regNumber,
        string vehicleType)
    {
        Console.WriteLine($"\nℹ️ " +
            $"{MapVehicleTypeToVehicleName(vehicleType)} [{regNumber}]: " +
            $"Parked at '{lot.GetAddress()}' in lot '{lot.GetParkingLotID()}'");
    }

    private string MapVehicleTypeToVehicleName(
        string selectedVehicleType
    ) => selectedVehicleType switch
    {
        VehicleTypeKeeper.AIRPLANE => "Airplane",
        VehicleTypeKeeper.BOAT => "Boat",
        VehicleTypeKeeper.BUS => "Bus",
        VehicleTypeKeeper.CAR => "Car",
        VehicleTypeKeeper.E_CAR => "E-car",
        VehicleTypeKeeper.MOTORCYCLE => "MC",
        _ => VehicleTypeKeeper.DEFAULT
    };

    internal void PrintCanNotAddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType)
    {
        Console.WriteLine($"\n⚠️ " +
            $"{MapVehicleTypeToVehicleName(vehicleType)} [{regNumber}] " +
            $"could not be parked at garage '{address}'");
    }

    internal void PrintVehicleRemovedFromToGarage(RegistrationNumber regNumber)
    {
        Console.WriteLine($"\nℹ️ Vehicle [{regNumber.Value}] " +
            $"is removed from garage");
    }

    internal void PrintCanNotRemoveVehicleFromGarage(string addr, string regNumber)
    {
        Console.WriteLine($"\n⚠️ Vehicle [{regNumber}] " +
            $"could not be removed from garage with address '{addr}'");
    }

    internal string ReadParkingLotId()
    {
        Console.Write("\n✏️ Enter parking lot id (number > 0): ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal string ReadGarageCapacity()
    {
        Console.Write("\n✏️ Enter garage capacity (number > 0): ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal void PrintCanNotCreateGarageWithSpecifiedCapacity(string capacity)
    {
        Console.WriteLine($"\n⚠️ Can not create garage with capacity '{capacity}'");
    }

    internal bool ReadGarageDescriptionOK(out GarageDescriptionItem garageDescription)
    {
        var listGarageTypes = $"""

        📋 Select garage to create:
                {GarageDescriptionKeeper.AIRPLANE.ID}) {GarageDescriptionKeeper.AIRPLANE.Description}
                {GarageDescriptionKeeper.BOAT.ID}) {GarageDescriptionKeeper.BOAT.Description}
                {GarageDescriptionKeeper.BUS.ID}) {GarageDescriptionKeeper.BUS.Description}
                {GarageDescriptionKeeper.CAR.ID}) {GarageDescriptionKeeper.CAR.Description}
                {GarageDescriptionKeeper.CAR_NO_ELECTRICAL_PARKING_LOTS.ID}) {GarageDescriptionKeeper.CAR_NO_ELECTRICAL_PARKING_LOTS.Description}
                {GarageDescriptionKeeper.E_CAR.ID}) {GarageDescriptionKeeper.E_CAR.Description}
                {GarageDescriptionKeeper.MC.ID}) {GarageDescriptionKeeper.MC.Description}
                {GarageDescriptionKeeper.MULTI.ID}) {GarageDescriptionKeeper.MULTI.Description}
        """;

        Console.WriteLine(listGarageTypes);
        Console.Write("\n✏️ Select garage to create (number): ");
        garageDescription = GetSelectedGarage(Console.ReadLine() ?? String.Empty);
        return garageDescription != GarageDescriptionKeeper.DEFAULT;
    }

    private GarageDescriptionItem GetSelectedGarage(
        string selectedGarageType)
    {
        return GarageDescriptionKeeper.GarageDescriptions.ContainsKey(
            selectedGarageType
        ) ? GarageDescriptionKeeper.GarageDescriptions[selectedGarageType]
        : GarageDescriptionKeeper.DEFAULT;
    }

    internal void PrintGarageCreated(IGarageInfo garageInfo)
    {
        Console.WriteLine($"\nℹ️ Garage [{garageInfo.Address.Value}] " +
            $"{garageInfo.Description}" +
            $"is created with capacity {garageInfo.Capacity}");
    }

    internal void PrintCouldNotCreateGarage(string addr, string capacity, GarageDescriptionItem garageDescription)
    {
        Console.WriteLine($"\n⚠️ Could not create garage '{garageDescription.Description}' " +
            $"at address '{addr}' " +
            $"with capacity '{capacity}'");
    }

    internal void PrintVehicleFind(ParkingLotInfoWithAddress parkingLotInfo)
    {
        Console.WriteLine($"\nℹ️ Vehicle [{parkingLotInfo.GetVehicleRegistrationNumber()}] " +
            $"of type '{parkingLotInfo.GetVehicleType()}' " +
            $"was find in garage at address '{parkingLotInfo.Address.Value}' " +
            $"in lot {parkingLotInfo.GetParkingLotID()}");
    }

    internal void PrintCanNotFindVehicleInAnyGarage(string regNumber)
    {
        Console.WriteLine($"\n⚠️ Could not find vehicle with vehicle " +
            $"with registration number '{regNumber}' " +
            $"in any garages");
    }
}
