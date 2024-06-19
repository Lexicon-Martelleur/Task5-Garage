
namespace Garage.Model.Vehicle;

/// <summary>
/// A record class used for constant description 
/// of vehicle types supported by the application,
/// used by <see cref="VehicleTypeKeeper"/>
/// </summary>
/// <param name="ID"></param>
/// <param name="Description"></param>
public record class VehicleTypeItem(string ID, string Description);
