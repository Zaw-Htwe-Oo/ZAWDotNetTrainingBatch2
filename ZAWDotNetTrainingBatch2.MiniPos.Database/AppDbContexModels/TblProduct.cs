using System;
using System.Collections.Generic;

namespace ZAWDotNetTrainingBatch2.MiniPos.Database.AppDbContexModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string? ProductCode { get; set; }

    public string? ProductItem { get; set; }

    public decimal? Price { get; set; }

    public bool? IsDelete { get; set; }

    public DateTime? CreateAt { get; set; }
}
