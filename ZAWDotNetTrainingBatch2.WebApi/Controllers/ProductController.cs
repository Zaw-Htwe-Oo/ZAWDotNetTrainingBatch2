using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZAWDotNetTrainingBatch2.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // process
            // data
            return Ok("Get");
        }
        [HttpPost]
        public IActionResult Creat()
        {
            // process
            // data
            return Ok("Creat");
        }
        [HttpPut]
        public IActionResult Upsert()
        {
            // process
            // data
            return Ok("Upsert");
        }
        [HttpPatch] 
        public IActionResult Update()
        {
            // process
            // data
            return Ok("Update");
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            // process
            // data
            return Ok("Delete");
        }
    }
}
