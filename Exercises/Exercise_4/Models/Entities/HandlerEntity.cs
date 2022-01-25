using System.ComponentModel.DataAnnotations;

namespace Exercise_4.Models.Entities
{
    public class HandlerEntity
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
