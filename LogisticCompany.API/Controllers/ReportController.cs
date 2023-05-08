using LogisticCompany.Business.Abstract;
using LogisticCompany.Entity.Vm;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogisticCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IMaintenanceService _maintenanceService;
        private readonly IMaintenanceHistoryService _maintenanceHistoryService;
        private readonly IReportService _reportService;

        public ReportController(IMaintenanceService maintenanceService, IMaintenanceHistoryService maintenanceHistoryService, IReportService reportService)
        {
            _maintenanceService = maintenanceService;
            _maintenanceHistoryService = maintenanceHistoryService;
            _reportService = reportService;
        }

        [ProducesResponseType(typeof(MaintenanceVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("MaintenanceForStatus")]
        public IActionResult MaintenanceForStatus(int statusId)
        {
            var result = _reportService.MaintenanceForStatus(statusId).Result;
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

         [ProducesResponseType(typeof(MaintenanceVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("ResponsibleUserInfo")]
        public IActionResult ResponsibleUserInfo()
        {
            var result = _reportService.ActionTypeCountReports().Result;
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [ProducesResponseType(typeof(MaintenanceVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("MonthlyMaintenance")]
        public IActionResult MonthlyMaintenance()
        {
            var result = _reportService.MonthlyMaintenance().Result;
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        } 
        
        [ProducesResponseType(typeof(MaintenanceVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("MaintenanceTimeReport")]
        public IActionResult MaintenanceTimeReport()
        {
            var result = _reportService.MaintenanceTimeReport().Result;
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
