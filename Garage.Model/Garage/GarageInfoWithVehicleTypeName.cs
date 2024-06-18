namespace Garage.Model.Garage;


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
}
