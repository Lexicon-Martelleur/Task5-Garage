using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;
public class ECarGarageFactory : IGarageFactory<ECarParkingLot, ECar>
{
    public IGarage<ECarParkingLot, ECar> CreateGarage(
        HashSet<ECarParkingLot> parkingLots)
    {
        return new BaseGarage<ECarParkingLot, ECar>(parkingLots);
    }

    public IGarage<ECarParkingLot, ECar> CreateGarage(uint capacity)
    {
        var parkingLotFactory = new ECarParkingLotFactory();
        var parkingLots = GarageUtility<
            ECarParkingLot,
            ECar
        >.CreateParkingLots(capacity, parkingLotFactory);
        return new BaseGarage<ECarParkingLot, ECar>(parkingLots);
    }
}

