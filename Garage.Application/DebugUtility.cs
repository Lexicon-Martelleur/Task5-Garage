using System.Diagnostics;

namespace Garage.Application;

internal class DebugUtility
{
    internal static void StartDebug()
    {
        var myWriter = new TextWriterTraceListener(System.Console.Out);
        Trace.Listeners.Add(myWriter);
        Debug.WriteLine("Debug mode is active");
    }
}
