using System;
using System.Collections.Generic;

namespace _01_AspNetWebApi_ForBlazor.Models
{
    public partial class ProductSubCategory
    {
        public ProductSubCategory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual ProductCategory Category { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
