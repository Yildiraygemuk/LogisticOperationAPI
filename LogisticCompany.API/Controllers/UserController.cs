using LogisticCompany.Business.Abstract;
using LogisticCompany.Business.Attributes;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [LogisticCompanyAuthorize]
        [ProducesResponseType(typeof(UserVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [LogisticCompanyAuthorize]
        [ProducesResponseType(typeof(UserVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);

            if (result.Data == null)
            {
                throw new NotFoundException(id);
            }
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(UserForRegisterDto userDto)
        {
            var result = await _userService.Post(userDto);
            return StatusCode(result.StatusCode, result);
        }
        [LogisticCompanyAuthorize]
        [HttpPut]
        public async Task<IActionResult> Put(UserDto userDto)
        {
            var result = await _userService.Update(userDto);
            return StatusCode(result.StatusCode, result);
        }
        [LogisticCompanyAuthorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
