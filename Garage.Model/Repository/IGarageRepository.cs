using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Repository;

/// <summary>
/// A repository type used to abstract garage storage.
/// </summary>
public interface IGarageRepository
{
    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages();
    
    IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles(
        Dictionary<string, string[]> filterMap);
    
    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(Address garageAddress);

    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles();

    public ParkingLotInfoWithAddress? AddVehicleToGarage<VehicleType>(
        string address,
        VehicleType vehicle)
        where VehicleType : IVehicle;

    public IGarageInfo? GetGarage(string addr);
    
    RegistrationNumber? RemoveVehicleFromGarage(string addr, uint parkingLotId);
    
    bool StoreGarage<VehicleType>(IGarage<VehicleType> garage)
        where VehicleType : IVehicle;
    
    ParkingLotInfoWithAddress? FindVehicleInAllGarages(string regNumber);
}
