using System;
using System.Collections.Generic;

namespace Rent.App.Models;

public partial class Car
{
    public int CarId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Plate { get; set; } = null!;

    public decimal DailyPrice { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
