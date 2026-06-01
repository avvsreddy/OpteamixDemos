using System;
using System.Collections.Generic;

namespace EFDbFirstDemo.DataLayer;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public decimal? Price { get; set; }

    public bool? InStock { get; set; }
}
