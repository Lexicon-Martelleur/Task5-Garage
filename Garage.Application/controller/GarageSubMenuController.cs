using Garage.Application.View;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Service;
using Garage.Model.Vehicle;

namespace Garage.Application.Controller;

/// <summary>
/// A controller class used to control data flow
/// for each sub menu described in <see cref="GarageMenuController"/>
/// </summary>
/// <param name="view">
/// A view type of <see cref="IGarageSubMenuView"/> used to read and write
/// information to and from the user.
/// </param>
/// <param name="service">A service of type <see cref="IGarageService"/> used to handle
/// garage domain logic</param>
internal class GarageSubMenuController(
    IGarageSubMenuView view,
    IGarageService service) : IGarageSubMenuController
{
    public void HandleListAllGarages()
    {
        view.PrintAllGarages(service.GetAllGarages());
    }

    public void HandleListAllVehicles()
    {
        var parkingLotInfos = service.GetAllParkingLotsWithVehicles();
        view.PrintParkingLotsWithVehicles(parkingLotInfos);
    }

    public void HandleListGroupedVehiclesByType()
    {
        if (Utility.EmptyInput(out var address, view.ReadGarageAddr, view.WriteNotValidInput))
        {
            return;
        }

        var groupedVehicles = service.GetGroupedVehiclesByVehicleType(address);
        view.PrintGroupedVehicles(groupedVehicles, address);
    }

    public void HandleAddVehicleToGarage()
    {
        if (Utility.EmptyInput(out var addr, view.ReadGarageAddr, view.WriteNotValidInput) ||
            Utility.EmptyInput(out var regNumber, view.ReadRegNr, view.WriteNotValidInput) ||
            Utility.InvalidVehicle(out var vehicleType, view.ReadVehicleType, view.WriteNotValidInput))
        {
            return;
        }

        var parkingLot = service.AddVehicleToGarage(addr, regNumber, vehicleType);
        if (parkingLot != null)
        {
            view.PrintVehicleAddedToGarage(parkingLot, regNumber, vehicleType);
        }
        else
        {
            view.PrintCanNotAddVehicleToGarage(addr, regNumber, vehicleType);
        }
    }

    public void HandleRemoveVehicleFromGarage()
    {
        if (Utility.EmptyInput(out var addr, view.ReadGarageAddr, view.WriteNotValidInput) ||
            Utility.EmptyInput(out var parkingLotId, view.ReadParkingLotId, view.WriteNotValidInput))
        {
            return;
        }

        if (!uint.TryParse(parkingLotId, out var parsedParkingLotId) || parsedParkingLotId == 0)
        {
            view.PrintCanNotRemoveVehicleFromGarage(addr, parkingLotId);
            return;
        }

        var regNumber = service.RemoveVehicleFromGarage(addr, parsedParkingLotId);

        if (regNumber != null)
        {
            view.PrintVehicleRemovedFromToGarage((RegistrationNumber)regNumber);
        }
        else
        {
            view.PrintCanNotRemoveVehicleFromGarage(addr, parkingLotId);
        }
    }

    public void HandleCreateGarage()
    {
        if (Utility.EmptyInput(out var addr, view.ReadGarageAddr, view.WriteNotValidInput) ||
            !view.ReadGarageDescriptionOK(out var description) ||
            Utility.EmptyInput(out var capacity, view.ReadGarageCapacity, view.WriteNotValidInput))
        {
            return;
        }

        if (!uint.TryParse(capacity, out var parsedCapacity) ||
            parsedCapacity == 0)
        {
            view.PrintCanNotCreateGarageWithSpecifiedCapacity(capacity);
            return;
        }

        IGarageInfo? garageInfo = service.CreateGarage(addr, parsedCapacity, description);
        if (garageInfo != null)
        {
            view.PrintGarageCreated(garageInfo);
        }
        else
        {
            view.PrintCouldNotCreateGarage(addr, capacity, description);
        }
    }

    public void HandleSearchVehicleByRegNumber()
    {
        if (Utility.EmptyInput(out var regNumber, view.ReadRegNr, view.WriteNotValidInput))
        {
            return;
        }

        ParkingLotInfoWithAddress? parkingLotInfo = service.FindVehicleInAllGarages(regNumber);
        if (parkingLotInfo != null)
        {
            view.PrintVehicleFind(parkingLotInfo);
        }
        else
        {
            view.PrintCanNotFindVehicleInAnyGarage(regNumber);
        }
    }

    public void HandleFilterVehicle()
    {
        var vehiclePropertyDescriptionMap = Vehicle.GetPropertyDescriptionMap();

        Dictionary<string, string[]> filterMap = new();

        foreach (var property in vehiclePropertyDescriptionMap)
        {
            string filterInput = view.ReadFilterProperty(property.Value);
            if (filterInput == String.Empty) { continue; }
            filterMap[property.Key] = SplitAndTrimInput(filterInput);
        }

        var parkingLotInfos = service.GetAllParkingLotsWithVehicles(filterMap);
        view.PrintFilteredVehicles(filterMap);
        view.PrintParkingLotsWithVehicles(parkingLotInfos);
    }

    private string[] SplitAndTrimInput(string input)
    {
        return input.Split(',')
                    .Select(s => s.Trim().ToUpper())
                    .ToArray();
    }
}
