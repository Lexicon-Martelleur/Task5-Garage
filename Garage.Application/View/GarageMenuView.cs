using Garage.Model.Service;

namespace Garage.Application.View;

internal class GarageMenuView
{
    internal void PrintMainMenu(GarageHolder garages)
    {
        uint counter = 1;
        Console.WriteLine("Select garage");
        counter = PrintAllCarGarages(garages.CarGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)),
            counter
        );
        counter = PrintAllCarGarages(garages.BusGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)),
            counter
        );
        counter = PrintAllCarGarages(garages.MCGarages.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)),
            counter
        );
        counter = PrintAllCarGarages(garages.BoatHarbors.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)),
            counter
        );
        counter = PrintAllCarGarages(garages.AirplaneHangars.Select(garage => new GarageInfo(
            garage.Address, garage.Capacity, garage.Description)),
            counter
        );
    }

    private uint PrintAllCarGarages(IEnumerable<GarageInfo> carGarages, uint counter)
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
        return $"\t{menuRow}) Garage at {info.address}: {info.description} with capacity of {info.capacity}.";
    }

    private readonly record struct GarageInfo(
        string address, uint capacity, string description
    );
}
