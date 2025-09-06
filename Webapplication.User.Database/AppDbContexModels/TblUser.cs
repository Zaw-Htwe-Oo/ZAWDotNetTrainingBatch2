using System;
using System.Collections.Generic;

namespace Webapplication.User.Database.AppDbContexModels;

public partial class TblUser
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Department { get; set; }

    public string? Email { get; set; }

    public decimal? Salary { get; set; }

    public string? MobileNo { get; set; }

    public string? Address { get; set; }

    public bool? IsDelete { get; set; }
}
