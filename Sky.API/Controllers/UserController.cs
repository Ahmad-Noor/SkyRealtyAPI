using Sky.API.Helpers;
using Sky.API.Middleware;
using Sky.Domain;
using Sky.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens; 
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Sky.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            // Check userName
            if (await CheckUserNameExistAsync(user.UserName))
            {
                return BadRequest(new { Message = "UserName Already Exist!" });
            }
            // check Email
            if (await CheckUserNameEmailAsync(user.Email))
            {
                return BadRequest(new { Message = "Email Already Exist!" });
            }
            //check password Strength
            var passwordCheck = CheckPasswordStrength(user.Password);
            if (!string.IsNullOrEmpty(passwordCheck))
            {
                return BadRequest(new { Message = passwordCheck });
            }
             
            user.Password = PasswordHasher.HashPassword(user.Password);
            await unitOfWork.UserRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            var user = await unitOfWork.UserRepository.SingleOrDefaultAsync(w => w.UserName == login.UserName);
            if (user == null)
            {
                return NotFound(new { Message = "User Not Found!" });
            }
            if (!PasswordHasher.VerifyPassword(login.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect!" });
            }

            var token = CreateJwtToken(user);

            return Ok(new
            {
                Token = token,
                Message = "Login Success"
            });

        }

        private async Task<bool> CheckUserNameExistAsync(string userName)
        {
            var user = await unitOfWork.UserRepository.SingleOrDefaultAsync(w => w.UserName == userName);
            return user != null;
        }
        private async Task<bool> CheckUserNameEmailAsync(string email)
        {
            var user = await unitOfWork.UserRepository.SingleOrDefaultAsync(w => w.Email == email);
            return user != null;
        }

        private string CheckPasswordStrength(string password)
        {
            if (!Regex.IsMatch(password, "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$"))
            {
                return "password must contain at least eight characters, at least one number and both lower and uppercase letters and least one special character";
            }
            return string.Empty;
        }
        private string CreateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes("AlphaSecuretKey.....");
            var jwrTokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                NotBefore = DateTime.Now.AddMinutes(-5),
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };

            var token = jwrTokenHandler.CreateToken(tokenDescriptor);
            return jwrTokenHandler.WriteToken(token);


        }
    }
}
