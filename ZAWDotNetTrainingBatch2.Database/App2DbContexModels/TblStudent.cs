using System;
using System.Collections.Generic;

namespace ZAWDotNetTrainingBatch2.Database.App2DbContexModels;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string? StudentNo { get; set; }

    public string? StudentName { get; set; }

    public string? StudentNameLocal { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? MobileNo { get; set; }

    public string? Email { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? FatherName { get; set; }

    public string MotherName { get; set; } = null!;

    public bool? DeleteFlag { get; set; }
}
