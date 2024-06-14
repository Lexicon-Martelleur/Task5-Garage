using Garage.Model.Service;

namespace Garage.Application.View;

internal class GarageMenuView
{
    internal (List<GarageInfo> GarageInfoItems, string UserInput) PrintMainMenu(GarageKeeper garages)
    {
        List<GarageInfo> garageInfoItems = []; 
        uint counter = 0;
        Console.WriteLine("\nStored garages in the system:");
        garageInfoItems.AddRange(garages.CarGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)));

        garageInfoItems.AddRange(garages.BusGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)));

        garageInfoItems.AddRange(garages.MCGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)));

        garageInfoItems.AddRange(garages.BoatHarbors.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)));

        garageInfoItems.AddRange(garages.AirplaneHangars.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)));

        counter = PrintAllGarages(garageInfoItems, counter + 1);

        Console.WriteLine($"Select garage by selecting menu 1-{counter} or enter (q/Q) to quit.");
        var userInput = Console.ReadLine() ?? "";
        return (GarageInfoItems: garageInfoItems, UserInput: userInput);
    }

    private uint PrintAllGarages(IEnumerable<GarageInfo> carGarages, uint counter)
    {
        var updatedCounter = counter;
        foreach (var garage in carGarages) 
        {
            Console.WriteLine(GetGarageInfo(garage, updatedCounter, "\t"));
            updatedCounter++;
        }
        return updatedCounter;
    }

    private string GetGarageInfo(GarageInfo info, uint menuRow, string preFix)
    {
        return $"{preFix}{menuRow}) Garage [{info.address}]: {info.description} with capacity of {info.capacity} vehicles.";
    }

    private string GetGarageInfo(GarageInfo info)
    {
        return $"Garage [{info.address}]: {info.description} with capacity of {info.capacity} vehicles.";
    }

    public string PrintGarageMenu(GarageInfo garageInfo)
    {
        Console.WriteLine($"\n\nSelect operation for {GetGarageInfo(garageInfo)}");
        Console.WriteLine("\t1) View info about garage");
        Console.WriteLine("\t2) List all parked vehicles");
        Console.WriteLine("\t3) Add vehicle");
        Console.WriteLine("\t4) Remove vehicle");
        Console.WriteLine("\t5) Search after vehicle registration number");
        Console.WriteLine("\t6) Filter vehicle");
        Console.WriteLine("\t(q/Q) Back to main menu");
        return Console.ReadLine() ?? "";
    }
}
