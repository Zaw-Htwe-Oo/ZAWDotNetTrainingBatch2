using System;
using System.Collections.Generic;

namespace Webapplication.User.Database.AppDbContexModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string ProductCode { get; set; } = null!;

    public string ProductItem { get; set; } = null!;

    public decimal Price { get; set; }

    public bool DeleteFlag { get; set; }

    public DateTime CreateAt { get; set; }
}
