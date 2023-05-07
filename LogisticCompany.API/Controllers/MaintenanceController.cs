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
        public IActionResult Get()
        {
            var result = _maintenanceService.GetListQueryable();
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
        public IActionResult GetById(int id)
        {
            var result = _maintenanceService.GetById(id);

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
        public IActionResult Post(MaintenanceDto maintenanceDto)
        {
            var result = _maintenanceService.Post(maintenanceDto).Result;
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public IActionResult Put(MaintenanceDto maintenanceDto)
        {
            var result = _maintenanceService.Update(maintenanceDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _maintenanceService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
