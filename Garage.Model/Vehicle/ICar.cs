using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Model.Vehicle;

public interface ICar : IVehicle
{
    public RegistrationNumber RegistrationNumber { get; }

    public CarBrand Brand { get; }
}
