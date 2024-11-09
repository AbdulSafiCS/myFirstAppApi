using dataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using myFirstAppApi.DTO;
using System.IdentityModel.Tokens.Jwt;

namespace myFirstAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(UserManager<AppUser> userManager, JwtHandler jwtHandler) : ControllerBase
    {
        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync(LoginRequest request)
        {
            AppUser? user = await userManager.FindByNameAsync(request.UserName);
            if (user == null) {
                return Unauthorized("invalid username");
            }
            bool success = await userManager.CheckPasswordAsync(user, request.Password);
            if(!success)
            {
                return Unauthorized("invalid password");
            }
            JwtSecurityToken token = await jwtHandler.GetSecurityTokenAsync(user);

            string jwtstring = new JwtSecurityTokenHandler().WriteToken(token);

            LoginResponse response = new()
            {
                Success = true,
                Message = "mom loves you!",
                Token = jwtstring
            };
            return Ok(response);
        }
    }
}
