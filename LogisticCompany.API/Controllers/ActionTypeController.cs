using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Entities.Exceptions;
using LogisticCompany.Entity.Dto;
using LogisticCompany.Entity.Vm;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionTypeController : ControllerBase
    {
        private readonly IActionTypeService _actionTypeService;

        public ActionTypeController(IActionTypeService actionTypeService)
        {
            _actionTypeService = actionTypeService;
        }

        [ProducesResponseType(typeof(ActionTypeVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public IActionResult Get()
        {
            var result = _actionTypeService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [ProducesResponseType(typeof(ActionTypeVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var result = _actionTypeService.GetById(id);

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
        public IActionResult Post(ActionTypeDto actionTypeDto)
        {
            var result = _actionTypeService.Post(actionTypeDto);
            return StatusCode(result.Result.StatusCode, result);
        }
        [HttpPut]
        public IActionResult Put(ActionTypeDto actionTypeDto)
        {
            var result = _actionTypeService.Update(actionTypeDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _actionTypeService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
