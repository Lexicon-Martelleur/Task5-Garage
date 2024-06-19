using Garage.Model.Base;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

/// <summary>
/// An interface used to describe a generic garage factory.
/// </summary>
/// <typeparam name="VehicleType">
/// A type parameter of <see cref="IVehicle"/> type or its subclasses.
/// </typeparam>
public interface IGarageFactory<VehicleType>
    where VehicleType : IVehicle
{
    IGarage<VehicleType> CreateGarage(
        HashSet<IParkingLot<VehicleType>> parkingLots,
        Address address,
        GarageDescriptionItem description);

    IGarage<VehicleType> CreateGarage(
        uint capacity,
        Address address,
        GarageDescriptionItem description);
}
