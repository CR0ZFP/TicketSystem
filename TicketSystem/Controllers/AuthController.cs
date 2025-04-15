using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TicketSystem.Data;
using TicketSystem.Entitites.Dto.Auth;
using TicketSystem.Entitites.Entities;

namespace TicketSystem.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private IConfiguration configuration;

        public AuthController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }

        [HttpPost("register")]
        public async Task <IActionResult> Register(UserCreateDto dto)
        {
            var User = new AppUser()
            {
                UserName = dto.Email.Split("@")[0],
                Email = dto.Email,
                EmailConfirmed = true,
                GivenName = dto.FirstName,
                FamilyName = dto.LastName
            };
            var result = await userManager.CreateAsync(User, dto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Szerepkör létrehozása, ha nem létezik
            if (userManager.Users.Count() == 1)
            {
                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                await userManager.AddToRoleAsync(User, "Admin");
            }
            else
            {
                if (!await roleManager.RoleExistsAsync("Worker"))
                    await roleManager.CreateAsync(new IdentityRole("Worker"));

                await userManager.AddToRoleAsync(User, "Worker");
            }

            return Ok("Successful registration.");
        }

        [HttpPost("login")]
        public async Task <IActionResult> Login(UserLoginDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user != null)
            {
                var result = await userManager.CheckPasswordAsync(user, dto.Password);
                if (result)
                {
                    // Generate JWT token
                    // Return token

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    foreach (var role in await userManager.GetRolesAsync(user))
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role));
                    }
                    int accessTokenExpiryInMinutes = 24 * 60;
                    var accessToken = GenerateAccessToken(claims, accessTokenExpiryInMinutes);
                    return Ok(new LoginResultDto()
                    {
                        AccessToken = new JwtSecurityTokenHandler().WriteToken(accessToken),
                        AccessTokenExpiration = DateTime.Now.AddMinutes(accessTokenExpiryInMinutes),
                    });
                    
                }
                else
                {
                    throw new Exception("Invalid Password");
                }
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        private JwtSecurityToken GenerateAccessToken(IEnumerable<Claim>? claims, int expiryInMinutes)
        {
            var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(configuration["jwt:key"] ?? throw new Exception("jwt:key not found in appsettings.json")));

            return new JwtSecurityToken(
                  issuer: "gmail.com",
                  audience: "gmail.com",
                  claims: claims?.ToArray(),
                  expires: DateTime.Now.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
        }
    }
}
