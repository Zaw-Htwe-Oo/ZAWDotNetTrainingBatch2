using System;
using System.Collections.Generic;

namespace Webapplication.User.Database.AppDbContexModels;

public partial class TblStaff
{
    public int StaffId { get; set; }

    public string? StaffCode { get; set; }

    public string? StaffName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Position { get; set; }

    public string? MobileNo { get; set; }

    public bool IsDelete { get; set; }
}
