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
        public async Task<IActionResult> Get()
        {
            var result = await _maintenanceHistoryService.GetListQueryable();
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
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _maintenanceHistoryService.GetById(id);

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
        public async Task<IActionResult> Post(MaintenanceHistoryDto maintenanceHistoryDto)
        {
            var result = await _maintenanceHistoryService.Post(maintenanceHistoryDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(MaintenanceHistoryPutDto maintenanceHistoryDto)
        {
            var result = await _maintenanceHistoryService.Update(maintenanceHistoryDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _maintenanceHistoryService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
