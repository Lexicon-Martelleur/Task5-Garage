using System.Text.Json;

namespace Garage.Application.View;

/// <summary>
/// A utility class for view classes.
/// </summary>
internal static class ViewUtility
{
    private static readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = false
    };

    internal static string GetFilterMapValues(Dictionary<string, string[]> filterMap)
    {
        return JsonSerializer.Serialize(filterMap, _jsonOptions);
    }
}
