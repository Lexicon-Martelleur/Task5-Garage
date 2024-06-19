using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public interface IGarageService
{
    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles();
    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages();
    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress);
    ParkingLotInfoWithAddress? AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType);
    RegistrationNumber? RemoveVehicleFromGarage(string addr, uint parkingLotId);
    IGarageInfo? CreateGarage(string addr, uint capacity, GarageDescriptionItem description);
}
