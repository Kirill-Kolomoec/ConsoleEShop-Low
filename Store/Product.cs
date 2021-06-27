using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Product
    {
        public string Name {  get;  set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; }
        public Product()
        {
            Name = "Name";
            Category = "Category";
            Description = "Description";
            Price = 0;
        }

        public Product(string Name, string Category, string Description, uint Price)
        {
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Price = Price;

        }
        
        public void Print()
        {
            Console.WriteLine("-------------------");
            Console.Write($"Name: {Name}\nCategory: {Category}\nDescription: {Description}\nPrice: {Price}grn.\n");
            Console.WriteLine("-------------------");

        }

    }
}
