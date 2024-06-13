using System;

namespace Garage.Model.Vehicle;

public interface IVehicle
{
    public string Color { get; set; }

    public PowerSource PowerSource { get; }
}
