using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Model.Vehicle;

public class Car : ICar
{
    public RegistrationNumber RegistrationNumber => throw new NotImplementedException();

    public CarBrand Brand => throw new NotImplementedException();

    public string Color { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public PowerSource PowerSource { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
