using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Model.Vehicle;

public interface IMotorcycle : IVehicle
{
    uint NoiseLevel { get; set; } 
}
