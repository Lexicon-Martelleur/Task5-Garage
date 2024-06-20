using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Application.View;

/// <summary>
/// An interface used to describe an IGarageSubMenuView
/// view type.
/// </summary>
internal interface IGarageSubMenuView
{
    void PrintAllGarages(IEnumerable<GarageInfoWithVehicleTypeName> garages);
    void PrintParkingLotsWithVehicles(IEnumerable<ParkingLotInfoWithAddress> parkingLotsInfos);
    void PrintCanNotAddVehicleToGarage(string address, string regNumber, string vehicleType);
    void PrintCanNotCreateGarageWithSpecifiedCapacity(string capacity);
    void PrintCanNotFindVehicleInAnyGarage(string regNumber);
    void PrintCanNotRemoveVehicleFromGarage(string addr, string regNumber);
    void PrintCouldNotCreateGarage(string addr, string capacity, GarageDescriptionItem garageDescription);
    void PrintGarageCreated(IGarageInfo garageInfo);
    void PrintGroupedVehicles(IEnumerable<GroupedVehicle>? groupedVehicles, string address);
    void PrintGroupedVehiclesEntries(IEnumerable<GroupedVehicle> groupedVehiclesEntries, string address);
    void PrintNoGarageFoundForAddress(string address);
    void PrintVehicleAddedToGarage(ParkingLotInfoWithAddress lot, string regNumber, string vehicleType);
    void PrintVehicleFind(ParkingLotInfoWithAddress parkingLotInfo);
    void PrintVehicleRemovedFromToGarage(RegistrationNumber regNumber);
    string ReadVehicleProperty(string value);
    string ReadGarageAddr();
    string ReadGarageCapacity();
    bool ReadGarageDescriptionOK(out GarageDescriptionItem garageDescription);
    string ReadParkingLotId();
    string ReadRegNr();
    string ReadVehicleType();
    void WriteNotValidInput(string input);
    void PrintFilteredVehicles(Dictionary<string, string[]> filterMap);
    void PrintSelectedVehicle(string vehicleType);
}