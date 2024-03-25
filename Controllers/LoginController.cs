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
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using AutoMapper;
namespace ASP.Net_core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Net_APIContext _context;
        private readonly IMapper _mapper;
        public AuthController(Net_APIContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }
        public class ApiException : Exception {
            public int StatusCode {  get; }
            public ApiException(int statusCode, string massage): base(massage)
            {
                StatusCode = statusCode;
            }
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
                else if(loginRequest.Username == "" && loginRequest.Password=="")
                {
                    return NotFound("String");
                }
                else
                {
                    return Unauthorized("Invalid usser or passwork");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new ApiException(StatusCodes.Status500InternalServerError, "Error update database"+ ex.Message);

            }
            catch (Exception ex)
            {
                throw new ApiException(StatusCodes.Status500InternalServerError, "Internal sever error: " +ex.Message);
            }
        }
        private string GennerateToken(Users users) {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("lethingocanhABCDEFGTHAKRJNS");
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
        public async Task<ActionResult> Logout()
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




