﻿namespace OutFitShop.Models
{
    public class Product
    {
        public Product() { }

        public Product(string title, Category.Categ categ, string details, decimal price, string image)
        {
           
            Title = title;
            Categ = categ;
            Details = details;
            Price = price;
            Image = image;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public Category.Categ Categ { get; set; } = Category.Categ.babies;
        public string Details { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Image { get; set; } = string.Empty;

       public OrderLine? OrderLine { get; set; }


      //  public List<OrderLine> OrderLine { get; set; } = new List<OrderLine>();




    }
}
