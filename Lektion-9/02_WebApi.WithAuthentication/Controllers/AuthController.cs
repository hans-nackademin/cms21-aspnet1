using _02_WebApi.WithAuthentication.Models;
using _02_WebApi.WithAuthentication.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace _02_WebApi.WithAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly IConfiguration _configuration;


        public AuthController(SqlContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(UserSignUpModel model)
        {
            if (await _context.Users.AnyAsync(x => x.Email == model.Email))
                return BadRequest();

            var userEntity = new UserEntity(model.FirstName, model.LastName, model.Email);
            userEntity.CreatePassword(model.Password);

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(UserSignInModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Incorrect email or password");

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
            if (user == null)
                return BadRequest("Incorrect email or password");

            if (!user.ValidatePassword(model.Password))
                return BadRequest("Incorrect email or password");


            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim("DisplayName", $"{user.FirstName} {user.LastName}")
                }),

                Expires = DateTime.Now.AddHours(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"))),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return Ok(token);

        }

    }
}
