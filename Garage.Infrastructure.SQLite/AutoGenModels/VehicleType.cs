using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Garage.Infrastructure.SQLite.AutoGenModels;

public partial class VehicleType
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("type")]
    public string Type { get; set; } = null!;

    [InverseProperty("VehicleType")]
    public virtual ICollection<ParkingLot> ParkingLots { get; set; } = new List<ParkingLot>();
}
