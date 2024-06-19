using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public static class GarageDescription
{
    public readonly static (string Description, string[] VehicleTypes) CAR = 
        (Description: "A car garage for all cars",
        VehicleTypes: [VehicleType.CAR, VehicleType.E_CAR]);

    public readonly static (string Description, string[] VehicleTypes) E_CAR = 
        (Description: "A car garage only for e-cars",
        VehicleTypes: [VehicleType.E_CAR]);

    public readonly static (string Description, string[] VehicleTypes) CAR_NO_ELECTRICAL_PARKING_LOTS = 
        (Description: "A car garage (OBS! No electrical parking lots)",
        VehicleTypes: [VehicleType.CAR, VehicleType.E_CAR]);

    public readonly static (string Description, string[] VehicleTypes) BUS = 
        (Description: "A bus garage",
        VehicleTypes: [VehicleType.BUS]);

    public readonly static (string Description, string[] VehicleTypes) MC = 
        (Description: "A motorcycle garage",
        VehicleTypes: [VehicleType.MOTORCYCLE]);

    public readonly static (string Description, string[] VehicleTypes) BOAT = 
        (Description: "A boat harbor",
        VehicleTypes: [VehicleType.BOAT]);

    public readonly static (string Description, string[] VehicleTypes) AIRPLANE = 
        (Description: "A airplane hangar",
        VehicleTypes: [VehicleType.AIRPLANE]);

    public readonly static (string Description, string[] VehicleTypes) MULTI = 
        (Description: "A multi garage",
        VehicleTypes: [
            VehicleType.CAR,
            VehicleType.E_CAR,
            VehicleType.BUS,
            VehicleType.MOTORCYCLE,
            VehicleType.BOAT,
            VehicleType.AIRPLANE
        ]);
}
