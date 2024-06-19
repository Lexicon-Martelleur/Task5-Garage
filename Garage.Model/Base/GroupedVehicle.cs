namespace Garage.Model.Base;

/// <summary>
/// Record class used when grouping and counting vehicles by types
/// used for garage domain logic,
/// </summary>
/// <param name="VehicleType"></param>
/// <param name="Count"></param>
public record class GroupedVehicle(
    string VehicleType,
    int Count
);
