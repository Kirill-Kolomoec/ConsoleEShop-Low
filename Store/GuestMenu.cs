using System;
using System.Collections.Generic;
using System.Text;
//1.1.Роль «Гость». Можливості: 
//-перегляд переліку товарів; 
//-пошук товару за назвою;
//-реєстрація опіковогозапису користувача; 
//-вхід до інтернет-магазинуз обліковим записом
namespace Store
{
    class GuestMenu
    {
        static int indexMainMenu = 0;
        private static void Escape()
        {
            bool tmp = true;
            while (tmp)
            {
                ConsoleKeyInfo ckey = Console.ReadKey();
                if (ckey.Key == ConsoleKey.Escape)
                {
                    tmp = false;
                }

            }

        }
        public static List<string> menuItems = new List<string>()
        {
                "Show all products",
                "Find product",
                "Registration",
                "Log in",
                "Log in(Admin)",
                "Exit"
        };
        public static void StartUp()
        {
            Console.Clear();
            
            Console.CursorVisible = false;
            
            Loop(menuItems);
        }

        public static void Loop(List<string> menuItems)
        {
            while (true)
            {
                Console.Clear();
                string selectedMenuItem = drawMainMenu(menuItems);

                if (selectedMenuItem == "Show all products")
                {
                    Console.Clear();
                    ProductList.Print();

                    Escape();

                }
                else if (selectedMenuItem == "Find product")
                {
                    Console.Clear();
                    ProductList.FindProduct();

                    Escape();

                }
                else if (selectedMenuItem == "Registration")
                {
                    Console.Clear();
                    RegisteredUserList.Registration();

                    Escape();

                }
                else if (selectedMenuItem == "Log in")
                {
                    Console.Clear();

                    RegisteredUserList.FindRegisteredUser();

                    Escape();

                }
                else if (selectedMenuItem == "Log in(Admin)")
                {
                    Console.Clear();

                    AdminList.FindAdmin();

                    Escape();

                }
                else if (selectedMenuItem == "Exit")
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
        }
        

        public static string drawMainMenu(List<string> items)
        {

            for (int i = 0; i < items.Count; i++)
            {
                if (i == indexMainMenu)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }
            ConsoleKeyInfo ckey = Console.ReadKey();
            if (ckey.Key == ConsoleKey.DownArrow)
            {
                if (indexMainMenu == items.Count - 1) { }
                else { indexMainMenu++; }
            }
            else if (ckey.Key == ConsoleKey.UpArrow)
            {
                if (indexMainMenu <= 0) { }
                else { indexMainMenu--; }
            }
            else if (ckey.Key == ConsoleKey.Enter)
            {
                return items[indexMainMenu];
            }
            else
            {
                return "";
            }
            Console.Clear();

            
            return "";

            
        }
    }
}
