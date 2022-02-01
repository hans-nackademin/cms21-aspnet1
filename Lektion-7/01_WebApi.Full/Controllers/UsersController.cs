using _01_WebApi.Full.Models;
using _01_WebApi.Full.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _01_WebApi.Full.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SqlContext _context;

        public UsersController(SqlContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = new List<UserModel>();
            foreach(var user in await _context.Users.ToListAsync())
                users.Add(new UserModel(user.Id, user.FirstName, user.LastName, user.Email));

            return users;
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserCreateModel model)
        {
            if (await _context.Users.AnyAsync(x => x.Email == model.Email))
                return Conflict("User with the same email address already exists");

            var userEntity = new UserEntity(model.FirstName, model.LastName, model.Email, model.Password);
            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return Ok(new UserModel(userEntity.Id, userEntity.FirstName, userEntity.LastName, userEntity.Email));
        }
    }
}
