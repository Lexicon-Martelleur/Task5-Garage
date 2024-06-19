using Garage.Model.Vehicle;

namespace Garage.Model.Garage;

public static class GarageDescription
{
    public readonly static GarageDescriptionItem DEFAULT = new(
        ID: "-1",
        Description: "DEFAULT",
        VehicleTypes: []);

    public readonly static GarageDescriptionItem AIRPLANE = new(
        ID: "1",
        Description: "A airplane hangar",
        VehicleTypes: [VehicleType.AIRPLANE]);

    public readonly static GarageDescriptionItem BOAT = new(
        ID: "2",
        Description: "A boat harbor",
        VehicleTypes: [VehicleType.BOAT]);

    public readonly static GarageDescriptionItem BUS = new(
        ID: "3",
        Description: "A bus garage",
        VehicleTypes: [VehicleType.BUS]);

    public readonly static GarageDescriptionItem CAR = new(
        ID: "4",
        Description: "A car garage for all cars",
        VehicleTypes: [VehicleType.CAR, VehicleType.E_CAR]);

    
    public readonly static GarageDescriptionItem CAR_NO_ELECTRICAL_PARKING_LOTS = new(
        ID: "5",
        Description: "A car garage (OBS! No electrical parking lots)",
        VehicleTypes: [VehicleType.CAR, VehicleType.E_CAR]);

    public readonly static GarageDescriptionItem E_CAR = new(
        ID: "6",
        Description: "A car garage only for e-cars",
        VehicleTypes: [VehicleType.E_CAR]);

    public readonly static GarageDescriptionItem MC = new(
        ID: "7",
        Description: "A motorcycle garage",
        VehicleTypes: [VehicleType.MOTORCYCLE]);    
    
    public readonly static GarageDescriptionItem MULTI = new(
        ID: "8",
        Description: "A multi garage",
        VehicleTypes: [
            VehicleType.CAR,
            VehicleType.E_CAR,
            VehicleType.BUS,
            VehicleType.MOTORCYCLE,
            VehicleType.BOAT,
            VehicleType.AIRPLANE
        ]);

    public static readonly Dictionary<string, GarageDescriptionItem> GarageDescriptions = new()
    {
        { AIRPLANE.ID, AIRPLANE },
        { BOAT.ID, BOAT },
        { BUS.ID, BUS },
        { CAR.ID, CAR },
        { CAR_NO_ELECTRICAL_PARKING_LOTS.ID, CAR_NO_ELECTRICAL_PARKING_LOTS },
        { E_CAR.ID, E_CAR },
        { MC.ID, MC },
        { MULTI.ID, MULTI }
    };
}
