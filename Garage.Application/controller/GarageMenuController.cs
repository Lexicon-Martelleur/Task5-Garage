using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Service;
using Garage.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Application.controller;

internal class GarageMenuController
{
    internal void Start()
    {
        var quitMenu = false;
        var garageStore = new GarageInMemoryStore();
        var garages = garageStore.GetAllGarages();
        do
        {            
            Console.WriteLine($"Garage address: {garages.CarGarage.Address}, garage capacity {garages.CarGarage.Capacity}, garage type: { garages.CarGarage.GarageType}");
            Console.WriteLine($"Garage address: {garages.BusGarage.Address}, garage capacity {garages.BusGarage.Capacity}, garage type: {garages.BusGarage.GarageType}");
            Console.WriteLine($"Garage address: {garages.MCGarage.Address}, garage capacity {garages.MCGarage.Capacity}, garage type: { garages.MCGarage.GarageType}");
            Console.WriteLine($"Garage address: {garages.BoatHarbour.Address}, garage capacity {garages.BoatHarbour.Capacity}, garage type: {garages.BoatHarbour.GarageType}");
            Console.WriteLine($"Garage address: {garages.AirplaneHangar.Address}, garage capacity {garages.AirplaneHangar.Capacity}, garage type: {garages.AirplaneHangar.GarageType}");

        } while (quitMenu);
    }
}
