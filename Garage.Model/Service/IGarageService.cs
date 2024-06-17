
namespace Garage.Model.Service;

public interface IGarageService
{
    public IEnumerable<ParkingLotInfo> GetAllParkingLotsWithVehicles();
    public IEnumerable<GarageInfo> GetAllGarages();
    public IEnumerable<ParkingLotInfo> GetGroupedVehiclesByType(string garageAddress);
}
