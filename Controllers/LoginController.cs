using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net_API.Data;
using Net_API.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ASP.Net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Net_APIContext _context;

        public AuthController(Net_APIContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<ActionResult<Users>> Login(LoginRequest loginRequest)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginRequest.Username && u.Password == loginRequest.Password);

                if (user != null && user.Password == loginRequest.Password)
                {
                    var token = GennerateToken(user);
                    return Ok(new { Token = token });
                }
                return Unauthorized();
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error update database");

            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Lỗi sử lý yêu cầu ");
            }
            
        }
        private string GennerateToken(Users users) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("lethingocanhABCDEFGTHAKRJNSNJFNJDJJFBKDBFKJDFJNDFSJ");
            var tokenDescreiption = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescreiption);
            return tokenHandler.WriteToken(token);
        }
        [HttpPost("logout")]
        public ActionResult Logout()
        {

            return Ok();
        }
    }


public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}




