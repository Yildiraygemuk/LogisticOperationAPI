using LogisticCompany.Business.Abstract;
using LogisticCompany.Entity.Vm;
using LogisticCompany.Entity.Vm.Report;
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

        [ProducesResponseType(typeof(MaintenanceForStatusVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("MaintenanceForStatus")]
        public async Task<IActionResult> MaintenanceForStatus(int statusId)
        {
            var result = await _reportService.MaintenanceForStatus(statusId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

         [ProducesResponseType(typeof(MaintenanceForStatusVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("ActionTypeCountReports")]
        public async Task<IActionResult> ActionTypeCountReports()
        {
            var result = await _reportService.ActionTypeCountReports();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [ProducesResponseType(typeof(MonthlyMaintenanceReportVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("MonthlyMaintenance")]
        public async Task<IActionResult> MonthlyMaintenance()
        {
            var result = await _reportService.MonthlyMaintenance();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        } 
        
        [ProducesResponseType(typeof(MaintenanceTimeReportVm), 200)]
        [ProducesResponseType(typeof(object), 403)]
        [ProducesResponseType(typeof(object), 401)]
        [HttpGet("MaintenanceTimeReport")]
        public async Task<IActionResult> MaintenanceTimeReport()
        {
            var result = await _reportService.MaintenanceTimeReport();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
