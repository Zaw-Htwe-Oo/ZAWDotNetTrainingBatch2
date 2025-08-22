using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data;

namespace ZAWDotNetTrainingBatch2.Dapper.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                var lst = db.Query<ProductModel>("select * from Tbl_Product;");
                return Ok(lst);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                var item = db.QueryFirstOrDefault<ProductModel>("select * from Tbl_Product where ProductId = @ProductId;", new
                {
                    ProductId = id
                });
                //if(item == null)
                if (item is null)
                {
                    return NotFound();
                }
                return Ok(item);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductRequestModel requestModel)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Product]
          ([ProductCode]
          ,[ProductName]
          ,[Price]
          ,[DeleteFlag])
    VALUES
          (@ProductCode
          ,@ProductName
          ,@Price
          ,0)";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                int result = db.Execute(query, requestModel);
                return Ok(result > 0 ? "Saving Successful." : "Saving Failed.");
            }
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateProduct(int id, ProductRequestModel requestModel)
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
  SET [ProductCode] = @ProductCode
     ,[ProductName] = @ProductName
     ,[Price] = @Price
WHERE ProductId = @ProductId";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                int result = db.Execute(query, new
                {
                    ProductCode = requestModel.ProductCode,
                    ProductName = requestModel.ProductName,
                    Price = requestModel.Price,
                    ProductId = id
                });
                return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
  SET DeleteFlag = 1
WHERE ProductId = @ProductId";
            using (IDbConnection db = new SqlConnection(_configuration.GetConnectionString("DbConnection")))
            {
                db.Open();
                int result = db.Execute(query, new
                {
                    ProductId = id
                });
                return Ok(result > 0 ? "Deleting Successful." : "Deleting Failed.");
            }
        }
    }

    //public class Test
    //{
    //    public Test(string name)
    //    {

    //    }
    //}

    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }
    }

    public class ProductRequestModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }

}
