using System;
using System.Collections.Generic;

namespace MVC.Blog.Database.AppDbContexModels;

public partial class TblBlog
{
    public string BlogId { get; set; } = null!;

    public string BlogTitle { get; set; } = null!;

    public string BlogAuthor { get; set; } = null!;

    public string BlogContent { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedAt { get; set; }

    public string? ModifiedBy { get; set; }

    public bool DeleteFlag { get; set; }
}
