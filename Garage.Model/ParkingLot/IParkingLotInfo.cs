namespace Garage.Model.ParkingLot;

public interface IParkingLotInfo
{
    uint ID { get; init; }

    string? VehicleRegistrationNumber { get; }

    string? VehicleTypeName { get; }
}
