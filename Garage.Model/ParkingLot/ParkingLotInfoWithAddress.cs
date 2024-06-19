using Garage.Model.Base;

namespace Garage.Model.ParkingLot;

/// <summary>
/// Class used to hold none generic parking lot data
/// and the address to the garage of the parking lot.
/// </summary>
/// <param name="Address"></param>
/// <param name="ParkingLotInfo"></param>
public record class ParkingLotInfoWithAddress(
    Address Address,
    IParkingLotInfo ParkingLotInfo
)
{
    public uint GetParkingLotID()
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
