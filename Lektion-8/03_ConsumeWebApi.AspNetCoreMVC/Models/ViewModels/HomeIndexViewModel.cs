﻿namespace _03_ConsumeWebApi.AspNetCoreMVC.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public ProductModel ProductForm { get; set; }
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
