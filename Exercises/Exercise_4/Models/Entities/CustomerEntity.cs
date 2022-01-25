using System.ComponentModel.DataAnnotations;

namespace Exercise_4.Models.Entities
{
    public class CustomerEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public ICollection<CaseEntity> Cases { get; set; }
    }
}
