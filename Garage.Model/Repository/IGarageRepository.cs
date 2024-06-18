﻿using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Repository;

public interface IGarageRepository
{
    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages();

    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(Address garageAddress);

    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles();

    public bool AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType,
        out ParkingLotInfoWithAddress? parkingLotInfo);
}
