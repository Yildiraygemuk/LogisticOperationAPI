using LogisticCompany.Core.Entities.Concrete;

namespace LogisticCompany.Entity.Entity
{
    public class Vehicle : BaseEntity
    {
        public string PlateNo { get; set; }
        public int VehicleTypeID { get; set; }
        public int UserID { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
    }
}
