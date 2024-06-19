namespace Garage.Model.Vehicle;

/// <summary>
/// A record class used for vehicle dimensions.
/// </summary>
/// <param name="Width"></param>
/// <param name="Length"></param>
/// <param name="Height"></param>
public readonly record struct Dimension(
    uint Width, 
    uint Length, 
    uint Height);
