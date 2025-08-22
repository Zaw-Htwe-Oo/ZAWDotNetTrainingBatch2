using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ZAWDotNetTrainingBatch2.WebApi.ADonet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public class ProductAdoDotNetController : ControllerBase
        {
            private readonly IConfiguration _configuration;

            public ProductAdoDotNetController(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            [HttpGet]
            public IActionResult GetProducts()
            {
                // Database Connection String ကို appsettings.json ကနေ ယူလိုက်ပါတယ်။
                string connectionString = _configuration.GetConnectionString("DbConnection")!;

                // SqlConnection နဲ့ SqlCommand ကို using statement နဲ့ ကြေညာထားတဲ့ resource တွေကို အလိုအလျောက် dispose လုပ်သွားအောင်ပါ။
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Tbl_Product WHERE DeleteFlag = 0;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // SqlDataReader က query ကနေပြန်လာတဲ့ data တွေကို တစ်ကြောင်းချင်းစီ ဖတ်ဖို့အတွက်ပါ။
                        SqlDataReader reader = command.ExecuteReader();
                        List<ProductModel> products = new List<ProductModel>();

                        while (reader.Read())
                        {
                            // Data reader ကနေဖတ်လို့ရတဲ့ data တွေကို ProductModel ထဲကို ထည့်ပါတယ်။
                            ProductModel product = new ProductModel
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ProductCode = Convert.ToString(reader["ProductCode"]),
                                ProductName = Convert.ToString(reader["ProductName"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                            };
                            products.Add(product);
                        }

                        // Connection ကို ပိတ်လိုက်ပါတယ်။
                        connection.Close();
                        return Ok(products);
                    }
                }
            }

            [HttpGet("{id}")]
            public IActionResult GetProductById(int id)
            {
                string connectionString = _configuration.GetConnectionString("DbConnection")!;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Tbl_Product WHERE ProductId = @ProductId AND DeleteFlag = 0;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Note: SQL Injection ကို ကာကွယ်ဖို့အတွက် SqlParameter ကို သုံးဖို့ လိုအပ်ပါတယ်။
                        command.Parameters.AddWithValue("@ProductId", id);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ProductModel product = new ProductModel
                            {
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ProductCode = Convert.ToString(reader["ProductCode"]),
                                ProductName = Convert.ToString(reader["ProductName"]),
                                Price = Convert.ToDecimal(reader["Price"]),
                                DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"])
                            };
                            connection.Close();
                            return Ok(product);
                        }
                        else
                        {
                            connection.Close();
                            return NotFound("Product not found.");
                        }
                    }
                }
            }

            [HttpPost]
            public IActionResult CreateProduct(ProductRequestModel requestModel)
            {
                string connectionString = _configuration.GetConnectionString("DbConnection")!;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"INSERT INTO Tbl_Product (ProductCode, ProductName, Price, DeleteFlag) 
                                 VALUES (@ProductCode, @ProductName, @Price, 0)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Request ကနေပါလာတဲ့ Data တွေကို Parameter အနေနဲ့ ထည့်ပေးပါတယ်။
                        command.Parameters.AddWithValue("@ProductCode", requestModel.ProductCode);
                        command.Parameters.AddWithValue("@ProductName", requestModel.ProductName);
                        command.Parameters.AddWithValue("@Price", requestModel.Price);

                        // ExecuteNonQuery() က INSERT, UPDATE, DELETE query တွေအတွက်သုံးပြီး affected rows အရေအတွက်ကို return ပြန်ပေးပါတယ်။
                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        return Ok(result > 0 ? "Saving Successful." : "Saving Failed.");
                    }
                }
            }

            [HttpPatch("{id}")]
            public IActionResult UpdateProduct(int id, ProductRequestModel requestModel)
            {
                string connectionString = _configuration.GetConnectionString("DbConnection")!;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"UPDATE Tbl_Product 
                                 SET ProductCode = @ProductCode, 
                                     ProductName = @ProductName, 
                                     Price = @Price 
                                 WHERE ProductId = @ProductId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", id);
                        command.Parameters.AddWithValue("@ProductCode", requestModel.ProductCode);
                        command.Parameters.AddWithValue("@ProductName", requestModel.ProductName);
                        command.Parameters.AddWithValue("@Price", requestModel.Price);

                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
                    }
                }
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteProduct(int id)
            {
                string connectionString = _configuration.GetConnectionString("DbConnection")!;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // ဒါက soft delete ပါ။ တကယ်မဖျက်ဘဲ DeleteFlag ကိုပဲ 1 ပြောင်းလိုက်တာပါ။
                    string query = "UPDATE Tbl_Product SET DeleteFlag = 1 WHERE ProductId = @ProductId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductId", id);

                        int result = command.ExecuteNonQuery();
                        connection.Close();

                        return Ok(result > 0 ? "Deleting Successful." : "Deleting Failed.");
                    }
                }
            }
        }
    }
    // Product Data ကို Database ကနေ ပြန်လာတဲ့ ပုံစံအတိုင်း လက်ခံဖို့အတွက်ပါ။

    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }
    }

    // User ကနေ Product အသစ်ထည့်တာ၊ ပြင်တာတွေအတွက် Request Body ကို လက်ခံဖို့ပါ။
    public class ProductRequestModel
    {
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}

