using System;
using System.Collections.Generic;

namespace MVC.Blog.Database.AppDbContexModels;

public partial class TblCategory
{
    public string CategoryId { get; set; } = null!;

    public string CategoryCode { get; set; } = null!;

    public string CategoryName { get; set; } = null!;
}
