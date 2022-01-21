using System.ComponentModel.DataAnnotations;

namespace _02_WebApi_BlazorWebAssembly.Models
{
    public class CategoryFormModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "Kategorin är för lång")]
        public string Name { get; set; }
    }
}
