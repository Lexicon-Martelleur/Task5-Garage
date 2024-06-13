﻿using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Garage
{
    public interface IGarage<ParkingLotType> : IEnumerable<ParkingLotType>
        where ParkingLotType : IParkingLot
    {
        uint Capacity { get; }
        ParkingLotType[] ParkingLots { get; init; }
        bool IsFullGarage();
        bool IsOccupiedLot(ParkingLotType parkingLot);
        bool TryAddVehicle(uint parkingLotId, IVehicle vehicle, out ParkingLotType? parkingLot);
        bool TryRemoveVehicle(uint parkingLotId, out IVehicle? vehicle);
    }
}