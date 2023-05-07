using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Entity.Vm
{
    public class MaintenanceVm
    {
        public int Id { get; set; }
        public string PlateNo { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime ExceptedTimeToFix { get; set; }
        public string ResponsibleUserName { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public string Status { get; set; }
    }
}
