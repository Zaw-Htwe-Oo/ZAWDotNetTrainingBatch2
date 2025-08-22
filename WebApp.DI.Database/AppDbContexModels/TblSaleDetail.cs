using System;
using System.Collections.Generic;

namespace WebApp.DI.Database.AppDbContexModels;

public partial class TblSaleDetail
{
    public int SaleDetailId { get; set; }

    public int? SaleId { get; set; }

    public string? ProductCode { get; set; }

    public string? ProductName { get; set; }

    public int? Qty { get; set; }

    public decimal? Price { get; set; }

    public DateTime? DateTime { get; set; }

    public bool? IsDelete { get; set; }
}
