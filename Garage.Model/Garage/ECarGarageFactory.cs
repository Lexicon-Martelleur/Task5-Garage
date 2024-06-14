using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public class ECarGarageFactory : IGarageFactory<ParkingLot<ECar>, ECar>
{
    public IGarage<ParkingLot<ECar>, ECar> CreateGarage(
        HashSet<ParkingLot<ECar>> parkingLots)
    {
        return new BaseGarage<ParkingLot<ECar>, ECar>(parkingLots);
    }

    public IGarage<ParkingLot<ECar>, ECar> CreateGarage(uint capacity)
    {
        var parkingLots = GarageUtility<
            ParkingLot<ECar>,
            ECar
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new BaseGarage<ParkingLot<ECar>, ECar>(parkingLots);
    }

    private ParkingLot<ECar> CreateParkingLot(uint id)
    {
        return new ParkingLot<ECar>() { ID = id };
    }
}

