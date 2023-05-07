using LogisticCompany.Core.Entities.Concrete;

namespace LogisticCompany.Entity.Entity
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }
        public string Email { get; set; }
        public byte[] PsrSalt { get; set; }
        public byte[] PsrHash { get; set; }
        public virtual ICollection<Maintenance> Maintenances { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
