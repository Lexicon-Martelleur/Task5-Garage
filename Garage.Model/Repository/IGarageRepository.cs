using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Repository;

public interface IGarageRepository
{
    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages();

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(Address garageAddress);

    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles();

    public bool AddVehicleToGarage<VehicleType>(
        string address,
        VehicleType vehicle,
        out ParkingLotInfoWithAddress? parkingLotInfo)
        where VehicleType : IVehicle;
}
