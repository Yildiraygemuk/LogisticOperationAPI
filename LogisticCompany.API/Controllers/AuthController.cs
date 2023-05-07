using LogisticCompany.Business.Abstract;
using LogisticCompany.Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            else if (userToLogin.Success && userToLogin.Data is null)
            {
                return Ok(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            return StatusCode(result.StatusCode, result);
        }
    }
}
