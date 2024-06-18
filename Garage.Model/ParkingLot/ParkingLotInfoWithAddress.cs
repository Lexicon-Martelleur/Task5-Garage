using Garage.Model.Base;

namespace Garage.Model.ParkingLot;

public record class ParkingLotInfoWithAddress(
    Address Address,
    IParkingLotInfo ParkingLotInfo
)
{
    public uint GetVehicleID()
    {
        return ParkingLotInfo.ID;
    }

    public string? GetVehicleRegistrationNumber()
    {
        return ParkingLotInfo.VehicleRegistrationNumber;
    }

    public string? GetVehicleType()
    {
        return ParkingLotInfo.VehicleTypeName;
    }

    public string GetAddress()
    {
        return Address.Value;
    }
}
