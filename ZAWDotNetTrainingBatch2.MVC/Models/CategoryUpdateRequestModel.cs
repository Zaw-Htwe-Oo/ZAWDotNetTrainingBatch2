namespace ZAWDotNetTrainingBatch2.MVC.Models
{
    public class CategoryEditRequestModel
    {
        public string CategoryId { get; set; }
        public string CategoryCode { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
    }
}
