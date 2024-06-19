using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Application.View;

/// <summary>
/// A view class used to display the garage sub menus
/// and read user input for the applications garage features.
/// </summary>
internal class GarageSubMenuView
{
    internal void PrintAllGarages(IEnumerable<GarageInfoWithVehicleTypeName> garages)
    {
        garages.ToList().ForEach(i => Console.WriteLine(GetGarageInfo(i)));
    }

    private string GetGarageInfo(GarageInfoWithVehicleTypeName garage)
    {
        return $"\t➡️ Garage [{garage.GetAddress()}]: " +
            $"{garage.GetDescription()} " +
            $"with capacity of {garage.GetCapacity()} vehicles";
    }

    internal void PrintAllParkingLotsWithVehicles(
        IEnumerable<ParkingLotInfoWithAddress> parkingLotsInfos)
    {
        parkingLotsInfos.ToList().ForEach(i => Console.WriteLine(GetParkingLotInfo(i)));
    }

    private string GetParkingLotInfo(ParkingLotInfoWithAddress lot)
    {
        return $"\t➡️ {lot.GetVehicleType()} " +
            $"[{lot.GetVehicleRegistrationNumber()}]: " +
            $"Parked at '{lot.GetAddress()}' in lot ID '{lot.GetParkingLotID()}'";
    }

    internal string ReadGarageAddr()
    {
        Console.Write("\n\t✏️ Enter a valid garage address: ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal void PrintNoGarageFoundForAddress(string address)
    {
        Console.WriteLine($"\n\t⚠️ No garage exist in the system with address: '{address}'");
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
        if (groupedVehiclesEntries.Count() == 0)
        {
            Console.WriteLine($"\n\tℹ️ Garage is empty");
        }
        else
        {
            Console.WriteLine($"\n\tℹ️ Garage [{address}] current status:");
            foreach (var item in groupedVehiclesEntries)
            {
                Console.WriteLine($"\t\t➡️ {item.Count} {item.VehicleType} entries");
            }
        }
    }

    internal void WriteNotValidInput(string input)
    {
        if (input == String.Empty)
        {
            Console.WriteLine("\n\t⚠️ An empty input is not valid");
        }
        else
        {
            Console.WriteLine($"\n\t⚠️ Input {input} is not valid");
        }
    }

    internal string ReadRegNr()
    {
        Console.Write("\n\t✏️ Enter vehicle registration number: ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal string ReadVehicleType()
    {
        var listOfVehicleTypes = $"""

                📋 Vehicles types:
                        {VehicleTypeKeeper.AIRPLANE.ID}) {VehicleTypeKeeper.AIRPLANE.Description}
                        {VehicleTypeKeeper.BOAT.ID}) {VehicleTypeKeeper.BOAT.Description}
                        {VehicleTypeKeeper.BUS.ID}) {VehicleTypeKeeper.BUS.Description}
                        {VehicleTypeKeeper.CAR.ID}) {VehicleTypeKeeper.CAR.Description}
                        {VehicleTypeKeeper.E_CAR.ID}) {VehicleTypeKeeper.E_CAR.Description}
                        {VehicleTypeKeeper.MOTORCYCLE.ID}) {VehicleTypeKeeper.MOTORCYCLE.Description}
        """;

        Console.WriteLine(listOfVehicleTypes);
        Console.Write("\t✏️ Select vehicle type: ");
        var garageDescription = GetSelectedVehicleType(Console.ReadLine() ?? String.Empty);
        return garageDescription.ID;
    }

    private VehicleTypeItem GetSelectedVehicleType(
        string selectedVehicleType)
    {
        return VehicleTypeKeeper.VehicleDescriptions.ContainsKey(
            selectedVehicleType
        ) ? VehicleTypeKeeper.VehicleDescriptions[selectedVehicleType]
        : VehicleTypeKeeper.DEFAULT;
    }

    internal void PrintVehicleAddedToGarage(
        ParkingLotInfoWithAddress lot,
        string regNumber,
        string vehicleType)
    {
        Console.WriteLine($"\n\tℹ️ " +
            $"{MapVehicleTypeToVehicleName(vehicleType)} [{regNumber}]: " +
            $"Parked at '{lot.GetAddress()}' in lot '{lot.GetParkingLotID()}'");
    }

    private string MapVehicleTypeToVehicleName(string selectedVehicleType)
    {
        return VehicleTypeKeeper.VehicleDescriptions.ContainsKey(
            selectedVehicleType
        ) ? VehicleTypeKeeper.VehicleDescriptions[selectedVehicleType].Description
        : VehicleTypeKeeper.DEFAULT.Description;
    }

    internal void PrintCanNotAddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType)
    {
        Console.WriteLine($"\n\t⚠️ " +
            $"{MapVehicleTypeToVehicleName(vehicleType)} [{regNumber}] " +
            $"could not be parked at garage '{address}'");
    }

    internal void PrintVehicleRemovedFromToGarage(RegistrationNumber regNumber)
    {
        Console.WriteLine($"\n\tℹ️ Vehicle [{regNumber.Value}] " +
            $"is removed from garage");
    }

    internal void PrintCanNotRemoveVehicleFromGarage(string addr, string regNumber)
    {
        Console.WriteLine($"\n\t⚠️ Vehicle [{regNumber}] " +
            $"could not be removed from garage with address '{addr}'");
    }

    internal string ReadParkingLotId()
    {
        Console.Write("\n\t✏️ Enter parking lot id (number > 0): ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal string ReadGarageCapacity()
    {
        Console.Write("\n\t✏️ Enter garage capacity (number > 0): ");
        return Console.ReadLine() ?? String.Empty;
    }

    internal void PrintCanNotCreateGarageWithSpecifiedCapacity(string capacity)
    {
        Console.WriteLine($"\n\t⚠️ Can not create garage with capacity '{capacity}'");
    }

    internal bool ReadGarageDescriptionOK(out GarageDescriptionItem garageDescription)
    {
        var listGarageTypes = $"""

                📋 Garage types:
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
        Console.Write("\t✏️ Select garage to create (number): ");
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
        Console.WriteLine($"\n\tℹ️ Garage [{garageInfo.Address.Value}] " +
            $"{garageInfo.Description} " +
            $"is created with capacity {garageInfo.Capacity}");
    }

    internal void PrintCouldNotCreateGarage(string addr, string capacity, GarageDescriptionItem garageDescription)
    {
        Console.WriteLine($"\n\t⚠️ Could not create garage '{garageDescription.Description}' " +
            $"at address '{addr}' " +
            $"with capacity '{capacity}'");
    }

    internal void PrintVehicleFind(ParkingLotInfoWithAddress parkingLotInfo)
    {
        Console.WriteLine($"\n\tℹ️ Vehicle [{parkingLotInfo.GetVehicleRegistrationNumber()}] " +
            $"of type '{parkingLotInfo.GetVehicleType()}' " +
            $"was find in garage at address '{parkingLotInfo.Address.Value}' " +
            $"in lot '{parkingLotInfo.GetParkingLotID()}'");
    }

    internal void PrintCanNotFindVehicleInAnyGarage(string regNumber)
    {
        Console.WriteLine($"\n\t⚠️ Could not find vehicle with vehicle " +
            $"with registration number '{regNumber}' " +
            $"in any garages");
    }

    internal string ReadFilterProperty(string value)
    {
        Console.Write($"\n\t✏️ {value}: ");
        return Console.ReadLine() ?? String.Empty;
    }
}
