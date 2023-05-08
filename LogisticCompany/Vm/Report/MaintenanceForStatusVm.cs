using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Entity.Vm.Report
{
    public class MaintenanceForStatusVm
    {
        public string Status { get; set; }
        public int MaintenanceCount { get; set; }
        public List<MaintenanceVm> MaintenanceList { get; set; }
    }
}
