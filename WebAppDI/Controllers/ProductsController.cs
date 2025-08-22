using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.DI.Database.AppDbContexModels;

namespace WebAppDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetProducts(int pageNo, int pageSiz)
        {
            var products = _db.TblProducts
                .Skip((pageNo -1) * pageSiz)
                .ToList();

            return Ok(products);
        }
    }
}
