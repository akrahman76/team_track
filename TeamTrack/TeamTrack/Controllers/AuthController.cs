using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TeamTrack.Infrastructure.Identity;
using TeamTrack.Application.Interfaces;
using TeamTrack.Domain.Entities;

namespace TeamTrack.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _tokenService;

        public AuthController(UserManager<ApplicationUser> userManager, IJwtTokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string email, string password)
        {
            var domainUser = new User(email);
            var appUser = new ApplicationUser(domainUser);

            var result = await _userManager.CreateAsync(appUser, password);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Unauthorized();
            }

            var valid = await _userManager.CheckPasswordAsync(user, password);
            if (!valid)
            {
                return Unauthorized();
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = _tokenService.GenerateToken(user.Id, user.Email!, roles);

            return Ok(new { accessToken = token });
        }
    }
}