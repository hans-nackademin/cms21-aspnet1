using System;
using System.Collections.Generic;

namespace _01_AspNetWebApi_ForBlazor.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            ProductSubCategories = new HashSet<ProductSubCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
