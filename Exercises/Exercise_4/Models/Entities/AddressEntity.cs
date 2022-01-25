using System.ComponentModel.DataAnnotations;

namespace Exercise_4.Models.Entities
{
    public class AddressEntity
    {
        [Key]
        public int Id { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public virtual ICollection<CustomerEntity> Customers { get; set; }
    }
}
