using System;
using System.Collections.Generic;

namespace Rent.App.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerSurname { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
