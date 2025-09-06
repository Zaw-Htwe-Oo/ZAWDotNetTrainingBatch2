using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webapplication.User.Database.AppDbContexModels;

namespace WebApp.User.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _db;

        public UsersController(AppDbContext db)
        {

            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<TblUser>> GetUsersAsync()
        {
            var result = await _db.TblUsers.ToListAsync();
            return Ok(result);
        }
        
        [HttpGet ("{id}")]
        public async Task<ActionResult<TblUser>> GetUserByIdAsync(int id)
        {
            var user = await _db.TblUsers.FindAsync(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public async Task<ActionResult> AddUserAsync(TblUser user)
        {
            if (user is null)
            {
                return BadRequest("User is null");
            }
            await _db.TblUsers.AddAsync(user);
            await _db.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(int id, TblUser user)
        {
            if (id != user.UserId)
            {
                return BadRequest("User ID mismatch");
            }
            var existingUser = await _db.TblUsers.FindAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }
            existingUser.Name = user.Name;
            existingUser.Department = user.Department;
            existingUser.Email = user.Email;
            existingUser.Salary = user.Salary;
            existingUser.MobileNo = user.MobileNo;
            existingUser.Address = user.Address;
            existingUser.IsDelete = user.IsDelete;
            _db.TblUsers.Update(existingUser);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(int id,TblUser user)
        {
           
            var existingUser = await _db.TblUsers.FindAsync(id);
            if (existingUser is null)
            {
                return NotFound();
            }

            existingUser.IsDelete = true;
            _db.TblUsers.Update(existingUser);
            await _db.SaveChangesAsync();
            return Ok("Successfully Deleted!");
        }
    }       

        

    
}
