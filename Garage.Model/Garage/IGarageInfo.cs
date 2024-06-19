
using Garage.Model.Base;

namespace Garage.Model.Garage;

/// <summary>
/// A none generic interface used to describe
/// garage info data used to transfer data in the application.
/// </summary>
public interface IGarageInfo
{
    uint Capacity { get; }
    string Description { get; }
    string DescriptionWithVehicleTypes { get; }
    Address Address { get; }
}
