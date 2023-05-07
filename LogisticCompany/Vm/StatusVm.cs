using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Entity.Vm
{
    public class StatusVm
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public int ModifyBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
    }
}
