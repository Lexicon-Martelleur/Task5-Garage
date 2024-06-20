using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Garage.Infrastructure.SQLite.AutoGenModels;

public partial class Garage
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    [Column("name")]
    public string Name { get; set; } = null!;

    [Column("address")]
    public string? Address { get; set; }

    [InverseProperty("Garage")]
    public virtual ICollection<ParkingLot> ParkingLots { get; set; } = new List<ParkingLot>();
}
