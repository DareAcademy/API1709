using ClinicAngularAPI.Models;
using ClinicAngularAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ClinicAngularAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        IAccountService accountService;

        public AccountsController(IAccountService _accountService)
        {
            accountService = _accountService;
        }

        [HttpPost]
        [Route("Singup")]
        public async Task<IActionResult> Singup(SignUp signupDTO)
        {
            var result = await accountService.CreateAccount(signupDTO);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Errors);
            }

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(SignIn signIn)
        {
            var result = await accountService.SignIn(signIn);

            if (result.Succeeded)
            {
                List<Claim> authClaim = new List<Claim>();
                Claim claim = new Claim(ClaimTypes.Name, signIn.Username);
                authClaim.Add(claim);
                claim = new Claim("uniqueValue", Guid.NewGuid().ToString());
                authClaim.Add(claim);

                var user = await accountService.getUSerInfo(signIn.Username);

                var roles = accountService.getUserRoles(user);

                foreach (var item in roles)
                {
                    claim = new Claim(ClaimTypes.Role, item);
                    authClaim.Add(claim);
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisMySecurityKey"));

                var token = new JwtSecurityToken(
                            issuer: "http://localhost",
                            audience: "User",
                            expires: DateTime.Now.AddDays(15),
                            claims: authClaim,
                            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                            );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token)
                        });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole(List<UserRoles> userRoles)
        {
            await accountService.UpdateUserRoles(userRoles);
            userRoles = await accountService.getRoles(userRoles[0].UserId);

            return Ok(userRoles);
        }

        [HttpGet]
        [Route("UserRoles")]
        public async Task<IActionResult> UserRoles(string UserId)
        {

            List<UserRoles> userRoles = await accountService.getRoles(UserId);
            return Ok(userRoles);

        }

        [HttpGet]
        [Route("UserList")]
        public IActionResult UserList()
        {
            List<UsersDTO> users = accountService.getUsers();
            return Ok(users);

        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole(Role role)
        {
            var result = await accountService.AddRole(role);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return StatusCode(500, result.Errors);
            }
        }

        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string username)
        {
            var user = await accountService.getUSerInfo(username);

            var roles = accountService.getUserRoles(user);

            return Ok(roles);
        }




    }
}
