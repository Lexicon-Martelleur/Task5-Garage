using Garage.Model.Base;

namespace Garage.Model.Garage;


public record class GarageInfoWithVehicleTypeName(
    IGarageInfo GarageInfo,
    string VehicleType
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
