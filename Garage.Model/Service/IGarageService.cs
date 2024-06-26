﻿using Garage.Model.Base;
using Garage.Model.Garage;
using Garage.Model.ParkingLot;
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

/// <summary>
/// An interface used to describe a garage service used
/// to handle garage domain logic.
/// </summary>
public interface IGarageService
{
    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles();
    public IEnumerable<ParkingLotInfoWithAddress> GetAllParkingLotsWithVehicles(
        Dictionary<string, string[]> filterMap);
    public IEnumerable<GarageInfoWithVehicleTypeName> GetAllGarages();
    public IEnumerable<GroupedVehicle>? GetGroupedVehiclesByVehicleType(string garageAddress);
    ParkingLotInfoWithAddress? AddVehicleToGarage(
        string address,
        string regNumber,
        string vehicleType,
        Dictionary<string, string> creationMap);
    RegistrationNumber? RemoveVehicleFromGarage(string addr, uint parkingLotId);
    IGarageInfo? CreateGarage(string addr, uint capacity, GarageDescriptionItem description);
    ParkingLotInfoWithAddress? FindVehicleInAllGarages(string regNumber);
}
