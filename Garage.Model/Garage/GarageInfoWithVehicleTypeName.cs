﻿namespace Garage.Model.Garage;


/// <summary>
/// A none generic record class
/// used to transfer data in the application.
/// </summary>
/// <param name="GarageInfo"></param>
public record class GarageInfoWithVehicleTypeName(
    IGarageInfo GarageInfo
)
{
    public string GetAddress()
    {
        return GarageInfo.Address.Value;
    }

    public string GetDescription()
    {
        return GarageInfo.Description;
    }

    public uint GetCapacity()
    {
        return GarageInfo.Capacity;
    }

    public uint GetFreeParkingLots()
    {
        return GarageInfo.FreeParkingLots;
    }
}
