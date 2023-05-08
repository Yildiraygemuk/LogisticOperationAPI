using LogisticCompany.Business.Abstract;
using LogisticCompany.Business.Attributes;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.API.Controllers
{
    [LogisticCompanyAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [ProducesResponseType(typeof(StatusVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public async Task<IActionResult> Get()
        {
            var result = await _statusService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [ProducesResponseType(typeof(StatusVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _statusService.GetById(id);

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
        [HttpPost]
        public async Task<IActionResult> Post(StatusDto statusDto)
        {
            var result = await _statusService.Post(statusDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(StatusPutDto statusDto)
        {
            var result = await _statusService.Update(statusDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _statusService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
