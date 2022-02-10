using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _00_WebApi.WithAuthenication;
using _00_WebApi.WithAuthenication.Models.Entitites;
using _00_WebApi.WithAuthenication.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace _00_WebApi.WithAuthenication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationController(SqlContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpModel m)
        {
            if (await _context.Users.AnyAsync(x => x.Email == m.Email))
                return BadRequest(new { errorMessage = "a user with the same email address already exists" });

            var userEntity = new UserEntity(m.FirstName, m.LastName, m.Email);
            userEntity.CreateSecurePassword(m.Password);

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult> SignIn(SignInModel m)
        {
            if(string.IsNullOrEmpty(m.Email) || string.IsNullOrEmpty(m.Password))
                return BadRequest("email address and password must be provided");

            var userEntity = await _context.Users.FirstOrDefaultAsync(x => x.Email == m.Email);
            if (userEntity == null)
                return BadRequest("incorrect email address or password");

            if(!userEntity.CompareSecurePassword(m.Password))
                return BadRequest("incorrect email address or password");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEntity.Id.ToString()),
                    new Claim("email", userEntity.Email)
                }),

                Expires = DateTime.Now.AddHours(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey"))),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            return Ok(tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)));
        }

    }
}
