using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;
using System.Text;

namespace Garage.Application.View;

/// <summary>
/// A view class used to display the garage sub menus
/// and read user input for the applications garage features.
/// </summary>
internal class GarageSubMenuView : IGarageSubMenuView
{
    public void PrintAllGarages(IEnumerable<GarageInfoWithVehicleTypeName> garages)
    {
        garages.ToList().ForEach(i => Console.WriteLine(GetGarageInfo(i)));
    }

    private string GetGarageInfo(GarageInfoWithVehicleTypeName garage)
    {
        return $"\t➡️ Garage [{garage.GetAddress()}]: " +
            $"{garage.GetDescription()} " +
            $"with capacity of {garage.GetCapacity()} vehicles";
    }

    public void PrintParkingLotsWithVehicles(
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

    public string ReadGarageAddr()
    {
        Console.Write("\n\t✏️ Enter a valid garage address: ");
        return Console.ReadLine()?.Trim() ?? String.Empty;
    }

    public void PrintNoGarageFoundForAddress(string address)
    {
        Console.WriteLine($"\n\t⚠️ No garage exist in the system with address: '{address}'");
    }

    public void PrintGroupedVehicles(
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

    public void PrintGroupedVehiclesEntries(
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

    public void WriteNotValidInput(string input)
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

    public string ReadRegNr()
    {
        Console.Write("\n\t✏️ Enter vehicle registration number: ");
        return Console.ReadLine()?.Trim() ?? String.Empty;
    }

    public string ReadVehicleType()
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
        Console.Write("\t✏️ Select vehicle type (number): ");
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

    public void PrintVehicleAddedToGarage(
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

    public void PrintCanNotAddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType)
    {
        Console.WriteLine($"\n\t⚠️ " +
            $"{MapVehicleTypeToVehicleName(vehicleType)} [{regNumber}] " +
            $"could not be parked at garage '{address}'");
    }

    public void PrintVehicleRemovedFromToGarage(RegistrationNumber regNumber)
    {
        Console.WriteLine($"\n\tℹ️ Vehicle [{regNumber.Value}] " +
            $"is removed from garage");
    }

    public void PrintCanNotRemoveVehicleFromGarage(string addr, string regNumber)
    {
        Console.WriteLine($"\n\t⚠️ Vehicle [{regNumber}] " +
            $"could not be removed from garage with address '{addr}'");
    }

    public string ReadParkingLotId()
    {
        Console.Write("\n\t✏️ Enter parking lot id (number > 0): ");
        return Console.ReadLine()?.Trim() ?? String.Empty;
    }

    public string ReadGarageCapacity()
    {
        Console.Write("\n\t✏️ Enter garage capacity (number > 0): ");
        return Console.ReadLine()?.Trim() ?? String.Empty;
    }

    public void PrintCanNotCreateGarageWithSpecifiedCapacity(string capacity)
    {
        Console.WriteLine($"\n\t⚠️ Can not create garage with capacity '{capacity}'");
    }

    public bool ReadGarageDescriptionOK(out GarageDescriptionItem garageDescription)
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
        garageDescription = GetSelectedGarage(Console.ReadLine()?.Trim() ?? String.Empty);
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

    public void PrintGarageCreated(IGarageInfo garageInfo)
    {
        Console.WriteLine($"\n\tℹ️ Garage [{garageInfo.Address.Value}] " +
            $"{garageInfo.Description} " +
            $"is created with capacity {garageInfo.Capacity}");
    }

    public void PrintCouldNotCreateGarage(string addr, string capacity, GarageDescriptionItem garageDescription)
    {
        Console.WriteLine($"\n\t⚠️ Could not create garage '{garageDescription.Description}' " +
            $"at address '{addr}' " +
            $"with capacity '{capacity}'");
    }

    public void PrintVehicleFind(ParkingLotInfoWithAddress parkingLotInfo)
    {
        Console.WriteLine($"\n\tℹ️ Vehicle [{parkingLotInfo.GetVehicleRegistrationNumber()}] " +
            $"of type '{parkingLotInfo.GetVehicleType()}' " +
            $"was find in garage at address '{parkingLotInfo.Address.Value}' " +
            $"in lot '{parkingLotInfo.GetParkingLotID()}'");
    }

    public void PrintCanNotFindVehicleInAnyGarage(string regNumber)
    {
        Console.WriteLine($"\n\t⚠️ Could not find vehicle with vehicle " +
            $"with registration number '{regNumber}' " +
            $"in any garages");
    }

    public string ReadFilterProperty(string value)
    {
        Console.Write($"\n\t✏️ {value}: ");
        return Console.ReadLine()?.Trim() ?? String.Empty;
    }

    public void PrintFilteredVehicles(Dictionary<string, string[]> filterMap)
    {
        Console.WriteLine($"\nℹ️ Filtered vehicles [{GetFilterMapValues(filterMap)}]:");
    }

    private string GetFilterMapValues(Dictionary<string, string[]> filterMap)
    {
        var text = new StringBuilder("{ ");
        var counter = 0;
        foreach (var key in filterMap.Keys)
        {
            counter++;
            text.Append($"{key}: [");
            text.Append(string.Join(", ", filterMap[key]));
            if (counter == filterMap.Count)
            {
                text.Append("] ");
            }
            else
            {
                text.Append("], ");
            }
        }
        text.Append("}");
        return text.ToString();
    }
}
