using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Store
{
    class ProductList
    {
        public static List<Product> products = new List<Product>();
        private static Random rnd = new Random();

        private static string[] Name = { "Dog", "Cat", "Ball", "Car" };
        private static string[] Category = { "Toy", "Meat", "Game" };
        private static string[] Description = { "sdssssssss", "dssdsdsd", "eqewqeq" };
        private static uint[] Price = { 155, 15, 68, 89, 54665, 65 };

        public static void FillList()
        {
            for (int i = 0; i < 10; i++)
            {
                Product prod = new Product(Name[rnd.Next(0, 4)], Category[rnd.Next(0, 3)], Description[rnd.Next(0, 3)], Price[rnd.Next(0, 6)]);
                products.Add(prod);
            }
        }

        public static void AddNewProduct()
        {
            Product newProduct = new Product();
            Console.WriteLine("New product");
            Console.Write("Enter Name - ");
            newProduct.Name = Console.ReadLine();
            Console.Write("Enter Category - ");
            newProduct.Category = Console.ReadLine();
            Console.Write("Enter Description - ");
            newProduct.Description = Console.ReadLine();
            while (true)
            {
                try
                {
                    Console.Write("Enter Price - ");
                    newProduct.Price = Convert.ToUInt32(Console.ReadLine());
                    products.Add(newProduct);
                    Console.Write("Product has been succesfully added");
                    break;

                }
                catch (OverflowException)
                {
                    Console.WriteLine("Enter correct number\n");
                }
                
                catch (FormatException)
                {
                    Console.WriteLine("Enter correct number\n");
                }
            }
            



        }
        public static void EditProduct(int index)
        {
            Product newProduct = new Product();
            Console.WriteLine("Edit product");
            Console.Write("Enter Name - ");
            newProduct.Name = Console.ReadLine();
            Console.Write("Enter Category - ");
            newProduct.Category = Console.ReadLine();
            Console.Write("Enter Description - ");
            newProduct.Description = Console.ReadLine();
            Console.Write("Enter Price - ");
            newProduct.Price = Convert.ToUInt32(Console.ReadLine());
            products[index] = newProduct;
            Console.Write("Product has been succesfully edited");


        }


        public static void Print()
        {
            int n = 0;
            foreach (var item in products)
            {
                Console.WriteLine($"{n}");
                item.Print();
                n++;
            }
        }
        public static void FindProduct()
        {
            string search;

            while (true)
            {
                Console.Write("Enter name of product: ");
                search = Console.ReadLine();
                if (search=="Stop"|| search == "stop"||search == "STOP")
                {
                    Console.Write("(Put on ESC to return to menu)\n");
                    break;
                }
                Product SearchedProductList = products.FirstOrDefault(s => s.Name == search);

                if (SearchedProductList == null)
                {
                    Console.WriteLine("There is not such product\n");
                }
                else
                {
                    SearchedProductList.Print();
                }
                Console.Write("(Enter Stop to stop serching)\n");
            }
            

            

        }
    }
}
