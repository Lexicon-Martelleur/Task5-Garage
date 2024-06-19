using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

/// <summary>
/// An interface used to describe a 
/// generic domain parking lot.
/// </summary>
/// <typeparam name="VehicleType">
/// A type parameter of <see cref="IVehicle"/> type or its subclasses.
/// </typeparam>
public interface IParkingLot<VehicleType> :
    IParkingLotInfo,
    IEquatable<IParkingLot<VehicleType>>
    where VehicleType : IVehicle
{
    VehicleType? CurrentVehicle { get; set; }
}
