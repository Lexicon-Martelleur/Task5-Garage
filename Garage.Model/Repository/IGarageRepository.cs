using Garage.Model.Garage;
using Garage.Model.Service;
using Garage.Model.Vehicle;

namespace Garage.Model.Repository;

public interface IGarageRepository
{
    public IEnumerable<GarageInfo> GetAllGarages();

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress);

    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles();
}
