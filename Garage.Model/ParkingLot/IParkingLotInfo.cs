namespace Garage.Model.ParkingLot;

/// <summary>
/// An interface used to describe none generic parking lot data.
/// </summary>
public interface IParkingLotInfo
{
    uint ID { get; init; }

    string? VehicleRegistrationNumber { get; }

    string? VehicleTypeName { get; }
}
