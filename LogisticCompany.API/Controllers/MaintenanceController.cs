using LogisticCompany.Business.Abstract;
using LogisticCompany.Business.Attributes;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.API.Controllers
{
    [LogisticCompanyAuthorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;

        public MaintenanceController(IMaintenanceService maintenanceService)
        {
            _maintenanceService = maintenanceService;
        }

        [ProducesResponseType(typeof(MaintenanceVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public async Task<IActionResult> Get()
        {
            var result = await _maintenanceService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [ProducesResponseType(typeof(MaintenanceVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _maintenanceService.GetById(id);

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
        public async Task<IActionResult> Post(MaintenanceDto maintenanceDto)
        {
            var result = await _maintenanceService.Post(maintenanceDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(MaintenancePutDto maintenanceDto)
        {
            var result = await _maintenanceService.Update(maintenanceDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(MaintenanceStatusDto maintenanceStatus)
        {
            var result = await _maintenanceService.UpdateStatus(maintenanceStatus);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _maintenanceService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
