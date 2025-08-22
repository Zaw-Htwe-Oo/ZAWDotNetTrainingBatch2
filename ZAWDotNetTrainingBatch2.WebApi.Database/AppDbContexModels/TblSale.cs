using System;
using System.Collections.Generic;

namespace ZAWDotNetTrainingBatch2.WebApi.Database.AppDbContexModels;

public partial class TblSale
{
    public int SaleId { get; set; }

    public string VoucherNo { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public DateTime? SaleDate { get; set; }

    public bool DeleteFlag { get; set; }
}
