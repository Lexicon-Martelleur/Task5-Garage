using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public class GarageKeeper
{
    private IEnumerable<IGarage<IParkingLot<ICar>, ICar>> _carGarages = [];
    
    private IEnumerable<IGarage<IParkingLot<IBus>, IBus>> _busGarages = [];

    private IEnumerable<IGarage<IParkingLot<IMotorcycle>, IMotorcycle>> _mcGarages = [];

    private IEnumerable<IGarage<IParkingLot<IBoat>, IBoat>> _boatHarbors = [];

    private IEnumerable<IGarage<IParkingLot<IAirplane>, IAirplane>> _airplaneHangars = [];

    private IEnumerable<IGarage<IParkingLot<ECar>, ECar>> _eCarGarages = [];

    private IEnumerable<IGarage<IParkingLot<IVehicle>, IVehicle>> _multiGarages = [];

    public IEnumerable<IGarage<IParkingLot<ICar>, ICar>> CarGarages {
        get => _carGarages;
        init => _carGarages = value;
    }

    public IEnumerable<IGarage<IParkingLot<IBus>, IBus>> BusGarages
    {
        get => _busGarages;
        init => _busGarages = value;
    }

    public IEnumerable<IGarage<IParkingLot<IMotorcycle>, IMotorcycle>> MCGarages
    {
        get => _mcGarages;
        init => _mcGarages = value;
    }

    public IEnumerable<IGarage<IParkingLot<IBoat>, IBoat>> BoatHarbors
    {
        get => _boatHarbors;
        init => _boatHarbors = value;
    }

    public IEnumerable<IGarage<IParkingLot<IAirplane>, IAirplane>> AirplaneHangars
    {
        get => _airplaneHangars;
        init => _airplaneHangars = value;
    }

    public IEnumerable<IGarage<IParkingLot<ECar>, ECar>> ECarGarages
    {
        get => _eCarGarages;
        init => _eCarGarages = value;
    }

    public IEnumerable<IGarage<IParkingLot<IVehicle>, IVehicle>> MultiGarages
    {
        get => _multiGarages;
        init => _multiGarages = value;
    }
}
