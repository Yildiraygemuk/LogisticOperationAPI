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
    public class VehicleTypeController : ControllerBase
    {
        private readonly IVehicleTypeService _vehicleTypeService;

        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        [ProducesResponseType(typeof(VehicleTypeVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public IActionResult Get()
        {
            var result = _vehicleTypeService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [ProducesResponseType(typeof(VehicleTypeVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _vehicleTypeService.GetById(id);

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
        public IActionResult Post(VehicleTypeDto vehicleTypeDto)
        {
            var result = _vehicleTypeService.Post(vehicleTypeDto);
            return StatusCode(result.Result.StatusCode, result);
        }
        [HttpPut]
        public IActionResult Put(VehicleTypeDto vehicleTypeDto)
        {
            var result = _vehicleTypeService.Update(vehicleTypeDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _vehicleTypeService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
