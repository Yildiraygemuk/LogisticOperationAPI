using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Entity.Dto
{
    public class MaintenanceStatusDto
    {
        public int MaintenanceId { get; set; }
        public int StatusId { get; set; }
        public int ActionTypeId { get; set; }
    }
}
