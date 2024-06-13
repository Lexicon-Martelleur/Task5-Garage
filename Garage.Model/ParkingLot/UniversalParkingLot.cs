﻿using Garage.Model.Vehicle;

namespace Garage.Model.ParkingLot;

public class UniversalParkingLot : BaseParkingLot<IVehicle>
{
    public override bool Equals(object? obj)
    {
        return Equals(obj as UniversalParkingLot);
    }

    public override int GetHashCode()
    {
        return ID.GetHashCode();
    }
}
