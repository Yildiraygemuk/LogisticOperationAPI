using LogisticCompany.Business.Abstract;
using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Core.Utilities.Security.Jwt;
using LogisticCompany.DataAccess.Abstract.Repository;
using LogisticCompany.Entity.Entity;
using LogisticCompany.Entity.Vm;
using LogisticCompany.Entity.Vm.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Business.Concrete
{
    public class ReportService:IReportService
    {
        private readonly IMaintenanceHistoryRepository _maintenanceHistoryRepository;
        private readonly IMaintenanceService _maintenanceService;
        private readonly IStatusRepository _statusRepository;

        public ReportService(IMaintenanceHistoryRepository maintenanceHistoryRepository, IMaintenanceService maintenanceService, IStatusRepository statusRepository)
        {
            _maintenanceHistoryRepository = maintenanceHistoryRepository;
            _maintenanceService = maintenanceService;
            _statusRepository = statusRepository;
        }

        public async Task<IDataResult<IQueryable<MaintenanceForStatusVm>>> MaintenanceForStatus(int statusId)
        {
            var maintenances = _maintenanceService.GetListQueryable().Data;
            var statusName = _statusRepository.GetById(statusId)?.Name;
            var maintenancesReport = maintenances
                .Where(m => m.Status == statusName)
                .GroupBy(m => m.Status)
                .Select(g => new MaintenanceForStatusVm
                {
                    Status = g.Key,
                    MaintenanceCount = g.Count(),
                    MaintenanceList = g.Select(m => new MaintenanceVm
                    {
                        Id= m.Id,
                        PlateNo = m.PlateNo,
                        UserName = m.UserName,
                        Description = m.Description,
                        Status = m.Status
                    }).ToList()
                })
                .AsQueryable();

            return new SuccessDataResult<IQueryable<MaintenanceForStatusVm>>(maintenancesReport);
        }
        public async Task<IDataResult<IQueryable<ActionTypeReportVm>>> ActionTypeCountReports()
        {
            var maintenanceHistoryList = _maintenanceHistoryRepository.GetAll();

            var result = maintenanceHistoryList
                .GroupBy(h => h.ActionTypeId)
                .Select(g => new ActionTypeReportVm { ActionTypeId = g.Key, Count = g.Count() })
                .AsQueryable();

            return new SuccessDataResult<IQueryable<ActionTypeReportVm>>(result);
        }
        public async Task<IDataResult<IQueryable<MonthlyMaintenanceReportVm>>> MonthlyMaintenance()
        {
            var maintenanceHistoryList = _maintenanceHistoryRepository.GetAll();

            var maintenanceByMonth = maintenanceHistoryList
                    .GroupBy(h => new { Year = h.CreatedDate.Year, Month = h.CreatedDate.Month })
                    .Select(g => new MonthlyMaintenanceReportVm { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
                    .OrderBy(g => g.Year)
                    .ThenBy(g => g.Month);

            return new SuccessDataResult<IQueryable<MonthlyMaintenanceReportVm>>(maintenanceByMonth);
        } 
        
        public async Task<IDataResult<IQueryable<MaintenanceTimeReportVm>>> MaintenanceTimeReport()
        {
            var maintenanceHistoryList = _maintenanceService.GetListQueryable();

            var result = maintenanceHistoryList.Data
                     .Select(m => new MaintenanceTimeReportVm {MaintenanceId= m.Id, Hour = (DateTime.Now.ToUniversalTime() - m.ExceptedTimeToFix.ToUniversalTime()).TotalHours.ToString("N2") })
                     .AsQueryable();

            return new SuccessDataResult<IQueryable<MaintenanceTimeReportVm>>(result);
        }
    }
}
