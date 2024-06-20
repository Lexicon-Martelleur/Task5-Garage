using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Garage.Infrastructure.SQLite.AutoGenModels;

[Index("RegistrationNumber", IsUnique = true)]
public partial class Vehicle
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("vehicle_type_id")]
    public int? VehicleTypeId { get; set; }

    [Column("parking_lot_id")]
    public int? ParkingLotId { get; set; }

    [Column("registration_number")]
    public string RegistrationNumber { get; set; } = null!;

    [Column("color")]
    public string? Color { get; set; }

    [Column("power_source")]
    public string? PowerSource { get; set; }

    [Column("vehicle_weight")]
    public int? VehicleWeight { get; set; }

    [ForeignKey("ParkingLotId")]
    [InverseProperty("Vehicles")]
    public virtual ParkingLot? ParkingLot { get; set; }
}
