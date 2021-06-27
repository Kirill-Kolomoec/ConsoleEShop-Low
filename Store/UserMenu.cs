using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class UserMenu
    {
        static int indexMainMenu = 0;

        static int IndexUser;

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
                "Ordering",
                "Order history",
                "Change login",
                "Change password",
                "Sign out"
        };
        public static void StartUp(int Index)
        {
            Console.Clear();
            IndexUser = Index;
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
                else if (selectedMenuItem == "Ordering")
                {
                    Console.Clear();
                    Order order = new Order();
                    order.Ordering();

                    RegisteredUserList.GetUser(IndexUser).OrderList.Add(order);
                    Escape();

                }
                else if (selectedMenuItem == "Order history")
                {
                    Console.Clear();
                    

                    RegisteredUserList.GetUser(IndexUser).ShowOrderList();

                    Escape();

                }
                else if (selectedMenuItem == "Change login")
                {
                    Console.Clear();
                    
                    Console.Write("Enter new login: ");
                    
                    RegisteredUserList.GetUser(IndexUser).Login = Console.ReadLine();
                    Console.Write($"Login has been changed on { RegisteredUserList.GetUser(IndexUser).Login}!");


                    Escape();


                }
                else if (selectedMenuItem == "Change password")
                {
                    Console.Clear();

                    

                    bool loop = true;
                    while (loop)
                    {
                        Console.Write("Enter actual password: ");
                        if (Console.ReadLine() == RegisteredUserList.GetUser(IndexUser).Password)
                        {
                            
                            Console.Write("Enter new password: ");
                            
                            RegisteredUserList.GetUser(IndexUser).Password = Console.ReadLine();
                            Console.Write($"Password has been changed!");
                            loop = false;
                        }
                        else
                        {
                            Console.WriteLine("Password is wrong");

                        }
                    }

                    Escape();
                }
                else if (selectedMenuItem == "Sign out")
                {
                    Console.Clear();
                    GuestMenu.StartUp();
                    Escape();
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
