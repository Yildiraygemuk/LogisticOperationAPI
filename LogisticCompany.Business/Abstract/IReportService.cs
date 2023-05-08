using LogisticCompany.Core.Utilities.Results;
using LogisticCompany.Entity.Vm.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Business.Abstract
{
    public interface IReportService
    {
        Task<IDataResult<IQueryable<MaintenanceForStatusVm>>> MaintenanceForStatus(int statusId);
        Task<IDataResult<IQueryable<ActionTypeReportVm>>> ActionTypeCountReports();
        Task<IDataResult<IQueryable<MonthlyMaintenanceReportVm>>> MonthlyMaintenance();
        Task<IDataResult<IQueryable<MaintenanceTimeReportVm>>> MaintenanceTimeReport();
    }
}
