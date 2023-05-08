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
    public class PictureGroupController : ControllerBase
    {
        private readonly IPictureGroupService _pictureGroupService;

        public PictureGroupController(IPictureGroupService pictureGroupService)
        {
            _pictureGroupService = pictureGroupService;
        }

        [ProducesResponseType(typeof(PictureGroupVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetList")]
        public async Task<IActionResult> Get()
        {
            var result = await _pictureGroupService.GetListQueryable();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [ProducesResponseType(typeof(PictureGroupVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _pictureGroupService.GetById(id);

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
        public async Task<IActionResult> Post(PictureGroupDto pictureGroupDto)
        {
            var result = await _pictureGroupService.Post(pictureGroupDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpPut]
        public async Task<IActionResult> Put(PictureGroupPutDto pictureGroupDto)
        {
            var result = await _pictureGroupService.Update(pictureGroupDto);
            return StatusCode(result.StatusCode, result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pictureGroupService.Delete(id);
            return StatusCode(result.StatusCode, result);
        }
    }
}
