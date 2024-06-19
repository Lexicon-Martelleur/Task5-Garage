
using Garage.Model.Vehicle;

namespace Garage.Application.Controller;

/// <summary>
/// A utility class used for testing user input
/// </summary>
internal static class Utility
{
    internal static bool EmptyInput(
        out string value,
        Func<string> ReadFromUser,
        Action<string> WriteCorrectionToUser)
    {
        return InvalidInput(
            out value,
            ReadFromUser,
            WriteCorrectionToUser,
            (string value) => value.Equals(String.Empty));
    }

    public static bool InvalidVehicle(
        out string vehicleType,
        Func<string> ReadFromUser,
        Action<string> WriteCorrectionToUser)
    {
        return Utility.InvalidInput(
            out vehicleType,
            ReadFromUser,
            WriteCorrectionToUser,
            (string value) => value.Equals(VehicleTypeKeeper.DEFAULT));
    }

    internal static bool InvalidInput(
        out string value,
        Func<string> ReadFromUser,
        Action<string> WriteCorrectionToUser,
        Func<string, bool> Predicate)
    {
        value = ReadFromUser();
        if (Predicate(value))
        {
            WriteCorrectionToUser(value);
            return true;
        }
        return false;
    }
}
