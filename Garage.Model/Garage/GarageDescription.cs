namespace Garage.Model.Garage;

public class GarageDescription
{
    public static readonly (string Garage, string Vehicle) CAR = (
        Garage: "A standard car garage for all cars",
        Vehicle: "cars"
    );

    public static readonly (string Garage, string Lot) E_CAR = (
        Garage: "A car garage only for e-cars",
        Lot: "electrical cars"
    );

    public static readonly (string Garage, string Lot) CAR_NO_ELECTRICAL_PARKING_LOTS = (
        Garage: "A car garage (OBS! No electrical parking lots)",
        Lot: "cars (OBS! No electrical parking lots)"
    );

    public static readonly (string Garage, string Lot) BUS = (
        Garage: "A standard bus garage",
        Lot: "buses"
    );

    public static readonly (string Garage, string Lot) MC = (
        Garage: "A standard motorcycle garage",
        Lot: "motorcycles" 
    );

    public static readonly (string Garage, string Lot) BOAT = 
    (
        Garage: "A standard boat harbor",
        Lot: "boats"
    );

    public static readonly (string Garage, string Lot) AIRPLANE = (
        Garage: "A standard airplane hangar",
        Lot: "airplanes"
    );

    public static readonly (string Garage, string Lot) MULTI = (
        Garage: "A standard multi garage",
        Lot: "all types of vehicles"
    );
}
