
namespace Garage.Model.Service;

public interface IGarageService
{
    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles();
    public IEnumerable<GarageInfo> GetAllGarages();
    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress);
}
