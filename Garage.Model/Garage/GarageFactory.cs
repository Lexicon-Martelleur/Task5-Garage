using Garage.Model.Base;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

/// <summary>
/// A factory class used to create generic garages.
/// </summary>
/// <typeparam name="VehicleType">
/// A type parameter of <see cref="IVehicle"/> type or its subclasses.
/// </typeparam>
public class GarageFactory<VehicleType> :
    IGarageFactory<VehicleType>
    where VehicleType : IVehicle
{
    public IGarage<VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        Address address,
        GarageDescriptionItem description
    )
    {
        return new Garage<VehicleType>(
            parkingLots,
            address,
            description);
    }

    public IGarage<VehicleType> CreateGarage(
        uint capacity,
        Address address,
        GarageDescriptionItem description
    )
    {
        var parkingLots = GarageUtility<
            IParkingLot<VehicleType>,
            VehicleType
        >.CreateParkingLots(capacity, CreateParkingLot);
        return new Garage<VehicleType>(
            parkingLots,
            address,
            description);
    }

    private IParkingLot<VehicleType> CreateParkingLot(uint id)
    {
        return new ParkingLot<VehicleType>() { ID = id };
    }
}
