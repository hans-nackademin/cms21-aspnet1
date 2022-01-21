using System;
using System.Collections.Generic;

namespace _01_AspNetWebApi_ForBlazor.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int SubCategoryId { get; set; }

        public virtual ProductSubCategory SubCategory { get; set; } = null!;
    }
}
