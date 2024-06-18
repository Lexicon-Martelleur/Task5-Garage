using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;

namespace Garage.Model.Service;

public interface IGarageService
{
    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles();
    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages();
    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress);
    bool AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType,
        out ParkingLotInfoWithAddress? parkingLotInfo);
}
