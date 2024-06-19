
namespace Garage.Model.Garage;

/// <summary>
/// A record class used as a constant data in class
/// <see cref="GarageDescriptionKeeper"/>.
/// </summary>
/// <param name="ID"></param>
/// <param name="Description"></param>
/// <param name="VehicleTypes"></param>
public record class GarageDescriptionItem(
    string ID,
    string Description,
    string[] VehicleTypes);
