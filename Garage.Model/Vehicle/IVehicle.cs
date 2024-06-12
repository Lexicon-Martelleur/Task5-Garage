using System;

namespace Garage.Model.Vehicle;

public interface IVehicle
{
    public RegistrationNumber RegistrationNumber { get; }

    public Brand Brand { get; }

    public string Color { get; set; }

    public PowerSource PowerSource { get; set; }
}
