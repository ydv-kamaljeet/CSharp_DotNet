using System;
using System.Collections.Generic;

namespace DbFirstDemo.Models;

public partial class Products
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? StockQty { get; set; }

    public DateOnly? AddedDate { get; set; }
}
