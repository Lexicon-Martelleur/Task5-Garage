﻿
using Garage.Model.Vehicle;

namespace Garage.Model.Service;

public record class ParkingLotInfo(
    string garageAddress,
    uint ParkinLotId,
    string vehicleRegNr,
    string parkingLotType,
    string vehicleType
);