using Garage.Model.Service;

namespace Garage.Application.View;

internal class GarageMenuView
{
    internal (List<GarageInfo> GarageInfoItems, string UserInput) PrintMainMenu(GarageHolder garages)
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
            Console.WriteLine(GetGarageInfo(garage, updatedCounter));
            updatedCounter++;
        }
        return updatedCounter;
    }

    private string GetGarageInfo(GarageInfo info, uint menuRow)
    {
        return $"\t{menuRow}) Garage [{info.address}]: {info.description} with capacity of {info.capacity}.";
    }

    public string PrintGarageMenu(GarageInfo garageInfo)
    {
        Console.WriteLine($"\n\nSelect ops for garage at address {garageInfo.address}");
        Console.WriteLine("\t 1) View info about garage");
        Console.WriteLine("\t 2) List all parked vehicles");
        Console.WriteLine("\t 3) Add car");
        Console.WriteLine("\t 4) Remove car");
        Console.WriteLine("\t 5) Search after car registration number");
        Console.WriteLine("\t 6) Filter cars");
        Console.WriteLine("\t (q/Q) Back to main menu");
        return Console.ReadLine() ?? "";
    }
}
