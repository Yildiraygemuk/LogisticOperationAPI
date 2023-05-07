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
    public class MaintenanceHistoryController : ControllerBase
    {
        private readonly IMaintenanceHistoryService _maintenanceHistoryService;

        public MaintenanceHistoryController(IMaintenanceHistoryService maintenanceHistoryService)
        {
            _maintenanceHistoryService = maintenanceHistoryService;
        }

        [ProducesResponseType(typeof(MaintenanceHistoryVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public IActionResult Get()
        {
            var result = _maintenanceHistoryService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [ProducesResponseType(typeof(MaintenanceHistoryVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _maintenanceHistoryService.GetById(id);

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
        public IActionResult Post(MaintenanceHistoryDto maintenanceHistoryDto)
        {
            var result = _maintenanceHistoryService.Post(maintenanceHistoryDto);
            return StatusCode(result.Result.StatusCode, result);
        }
        [HttpPut]
        public IActionResult Put(MaintenanceHistoryDto maintenanceHistoryDto)
        {
            var result = _maintenanceHistoryService.Update(maintenanceHistoryDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _maintenanceHistoryService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
