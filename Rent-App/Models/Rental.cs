using System;
using System.Collections.Generic;

namespace Rent.App.Models;

public partial class Rental
{
    public int RentalId { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public DateOnly RentDate { get; set; }

    public DateOnly ReturnDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
