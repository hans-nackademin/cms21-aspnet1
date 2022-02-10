using System.ComponentModel.DataAnnotations;

namespace _00_WebApi.AspNetMVC.Models.ViewModels
{
    public class ProductViewModel
    {
        [Display(Name = "Artikelnummer")]
        public int Id { get; set; }

        [Display(Name = "Namn")]
        public string Name { get; set; }

        [Display(Name = "Pris")]
        public decimal Price { get; set; }
    }
}
