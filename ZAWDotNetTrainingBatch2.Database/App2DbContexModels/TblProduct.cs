using System;
using System.Collections.Generic;

namespace ZAWDotNetTrainingBatch2.Database.App2DbContexModels;

public partial class TblProduct
{
    public int ProductId { get; set; }

    public string PName { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime? Createat { get; set; }

    public bool DeleteFlag { get; set; }
}
