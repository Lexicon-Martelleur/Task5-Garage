﻿
using Garage.Model.Base;

namespace Garage.Model.Garage;

public interface IGarageInfo
{
    uint Capacity { get; }
    string Description { get; }
    Address Address { get; }
}