using Garage.Model.Garage;

namespace Garage.Model.Vehicle;

// TODO! Finish implementation of VehicleFactory
// 1) Fix static creation of vehicle properties.
// 2) Update to write all properties or use unknown to simplify.

/// <summary>
/// A factory class used to add newly created vehicles
/// into the system.
/// </summary>
public class VehicleFactory
{
    public Car CreateGasolineCar(
        string regNumber,
        Dictionary<string, string> creationMap)
    {
        try
        {
            return new Car(
                new RegistrationNumber(regNumber),
                creationMap[VehicleUtility.CarBrandKey],
                creationMap[VehicleUtility.ColorKey],
                creationMap[VehicleUtility.PowerSourceKey],
                uint.Parse(creationMap[VehicleUtility.VehicleWeightKey]),
                ParseDimension(creationMap[VehicleUtility.VehicleDimensionKey])
            );
        }
        catch (Exception ex) {
            throw new InvalidGarageStateException(
                $"Invalid property for vehicle type of type car",
                ex
            );
        }
    }

    private Dimension ParseDimension(string dimensionInput)
    {
        string[] vehicleDimensionArray = dimensionInput.Split(',');
        if (vehicleDimensionArray.Length != 3)
        {
            throw new InvalidGarageStateException("Dimension input string must contain exactly three comma separated values.");
        }

        uint X = uint.Parse(vehicleDimensionArray[0]);
        uint Y = uint.Parse(vehicleDimensionArray[1]);
        uint Z = uint.Parse(vehicleDimensionArray[2]);
        return new(X, Y, Z);
    }

    public IBus CreateBus(
        string regNumber,
        Dictionary<string, string> creationMap)
    {
        try 
        {
            return new Bus(
                new RegistrationNumber(regNumber),
                uint.Parse(creationMap[VehicleUtility.StandingPassengerCapacityKey]),
                uint.Parse(creationMap[VehicleUtility.SittingPassengerCapacityKey]),
                creationMap[VehicleUtility.ColorKey],
                creationMap[VehicleUtility.PowerSourceKey],
                uint.Parse(creationMap[VehicleUtility.VehicleWeightKey]),
                ParseDimension(creationMap[VehicleUtility.VehicleDimensionKey])
            );
        }
        catch (Exception ex) {
            throw new InvalidGarageStateException(
                "Invalid property for vehicle of type bus",
                ex
            );
        }
    }

    public IMotorcycle CreateMC(
        string regNumber,
        Dictionary<string, string> creationMap)
    {
        try{
            return new Motorcycle(
                new RegistrationNumber(regNumber),
                uint.Parse(creationMap[VehicleUtility.NoiseLevelKey]),
                creationMap[VehicleUtility.ColorKey],
                creationMap[VehicleUtility.PowerSourceKey],
                uint.Parse(creationMap[VehicleUtility.VehicleWeightKey]),
                ParseDimension(creationMap[VehicleUtility.VehicleDimensionKey])
            );
        }
        catch (Exception ex)
        {
            throw new InvalidGarageStateException(
                "Invalid property for vehicle of type motorcycle",
                ex
            );
        }
    }

    public IBoat CreateBoat(
        string regNumber,
        Dictionary<string, string> creationMap)
    {
        try{
            return new Boat(
                new RegistrationNumber(regNumber),
                creationMap[VehicleUtility.BoatSteeringMechanismKey],
                creationMap[VehicleUtility.ColorKey],
                creationMap[VehicleUtility.PowerSourceKey],
                uint.Parse(creationMap[VehicleUtility.VehicleWeightKey]),
                ParseDimension(creationMap[VehicleUtility.VehicleDimensionKey])
            ); 
        }
        catch (Exception ex)
        {
            throw new InvalidGarageStateException(
                "Invalid property for vehicle of type boat",
                ex
            );
        }
    }

    public IAirplane CreateAirplane(
        string regNumber,
        Dictionary<string, string> creationMap)
    {
        try{
            return new Airplane(
                new RegistrationNumber(regNumber),
                uint.Parse(creationMap[VehicleUtility.WingSpanKey]),
                uint.Parse(creationMap[VehicleUtility.PassengerCapacityKey]),
                creationMap[VehicleUtility.ColorKey],
                creationMap[VehicleUtility.PowerSourceKey],
                uint.Parse(creationMap[VehicleUtility.VehicleWeightKey]),
                ParseDimension(creationMap[VehicleUtility.VehicleDimensionKey])
            );
        }
        catch (Exception ex)
        {
            throw new InvalidGarageStateException(
                "Invalid property for vehicle of type airplane",
                ex
            );
        }
    }

    public ECar CreateECar(
        string regNumber,
        Dictionary<string, string> creationMap)
    {
        try{
            return new ECar(
                new RegistrationNumber(regNumber),
                creationMap[VehicleUtility.CarBrandKey],
                creationMap[VehicleUtility.ColorKey],
                uint.Parse(creationMap[VehicleUtility.VehicleWeightKey]),
                ParseDimension(creationMap[VehicleUtility.VehicleDimensionKey])
            ); 
        }
        catch (Exception ex)
        {
            throw new InvalidGarageStateException(
                "Invalid property for vehicle of type e-car",
                ex
            );
        }
    }
}
