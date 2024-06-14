//using Garage.Model.Vehicle;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Garage.Model.ParkingLot;

//internal class BaseParkingLotFactory<ParkingLotType, VehicleType> :
//    IParkingLotFactory<ParkingLotType, VehicleType>
//    where VehicleType : IVehicle
//    where ParkingLotType : IParkingLot<VehicleType>, new()
//{
//    public ParkingLotType Create(uint id)
//    {
//        return new ParkingLotType { ID = id };
//    }
//}
