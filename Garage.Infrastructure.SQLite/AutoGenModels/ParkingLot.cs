using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Garage.Infrastructure.SQLite.AutoGenModels;

public partial class ParkingLot
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("garage_id")]
    public int? GarageId { get; set; }

    [Column("vehicle_type_id")]
    public int? VehicleTypeId { get; set; }

    [ForeignKey("GarageId")]
    [InverseProperty("ParkingLots")]
    public virtual Garage? Garage { get; set; }

    [ForeignKey("VehicleTypeId")]
    [InverseProperty("ParkingLots")]
    public virtual VehicleType? VehicleType { get; set; }

    [InverseProperty("ParkingLot")]
    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
