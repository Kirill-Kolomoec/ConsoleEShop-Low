using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class AdminMenu
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
                "Show users",
                "Add new product",
                "Edit product",
                "Change status of ordrer",
                "Sign out"
        };
        public static void StartUp(int Index)
        {
            Console.Clear();
            IndexUser = Index;
            Console.CursorVisible = false;
            AdminList.FillList();
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
                else if (selectedMenuItem == "Show users")
                {
                    Console.Clear();
                    RegisteredUserList.Print();
                    
                    try
                    {
                        Console.Write("(Enter esc to return to the menu)");
                        Console.WriteLine("\nWhich user do you like to edit - ");

                        
                        string index = Console.ReadLine();
                        if (index == "Stop" || index == "stop" || index == "STOP")
                        {
                            AdminMenu.StartUp(IndexUser);
                            break;
                        }
                        RegisteredUserList.EditUser(Convert.ToInt32(index));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("There is no product with such index, enter another index!\n");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("There is no product with such index, enter another index!\n");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter string instead of string\n");
                    }


                    Escape();

                }
                else if (selectedMenuItem == "Add new product")
                {
                    Console.Clear();

                    ProductList.AddNewProduct();

                    Escape();


                }
                else if (selectedMenuItem == "Edit product")
                {
                    Console.Clear();
                    ProductList.Print();

                    while (true)
                    {

                        try
                        {
                            Console.Write("(Enter Stop to return to the menu)");
                            Console.WriteLine("\nWhich product do you like to edit - ");
                            

                            string index = Console.ReadLine();
                            if (index == "Stop" || index == "stop" || index == "STOP")
                            {
                                AdminMenu.StartUp(IndexUser);
                                break;
                            }
                            ProductList.products[Convert.ToInt32(index)] =new Product();
                            ProductList.EditProduct(Convert.ToInt32(index));
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("There is no product with such index, enter another index!\n");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("There is no product with such index, enter another index!\n");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Enter string instead of string\n");
                        }
                    }

                    Escape();
                }
                else if (selectedMenuItem == "Change status of ordrer")
                {
                    Console.Clear();
                    Console.Clear();
                    RegisteredUserList.Print();

                    try
                    {
                        Console.Write("(Enter esc to return to the menu)");
                        Console.WriteLine("\nWhich user do you like to edit - ");


                        string index = Console.ReadLine();
                        if (index == "Stop" || index == "stop" || index == "STOP")
                        {
                            AdminMenu.StartUp(IndexUser);
                            break;
                        }

                        RegisteredUserList.GetUser(Convert.ToInt32(index)).ShowOrderList();

                        
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("There is no product with such index, enter another index!\n");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("There is no product with such index, enter another index!\n");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter string instead of string\n");
                    }

                    try
                    {
                        Console.Write("\n(Enter Stop to return to the menu)\n");
                        Console.WriteLine("\nWhich order do you like to edit - ");


                        string indexStatus = Console.ReadLine();
                        if (indexStatus == "Stop" || indexStatus == "stop" || indexStatus == "STOP")
                        {
                            AdminMenu.StartUp(IndexUser);
                            break;
                        }

                        RegisteredUserList.GetUser(IndexUser).OrderList[Convert.ToInt32(indexStatus)].ChangeStatusOrder();


                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("There is no product with such index, enter another index!\n");
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.WriteLine("There is no product with such index, enter another index!\n");
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter string instead of string\n");
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
