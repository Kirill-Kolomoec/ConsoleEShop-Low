using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    class AdminList
    {
        
        private static List<Admin> admins = new List<Admin>();


        public static void FillList()
        {
            admins.Add(new Admin("kirill", "cool"));

        }

        public static void FindAdmin()
        {
            FillList();
            bool loop = true;
            while(loop)
            {
                string search;
                Console.Write("\nEnter login: ");
                search = Console.ReadLine();

                Admin SearchedProductList = admins.FirstOrDefault(s => s.Login == search);
                
                if (SearchedProductList != null)
                {
                    foreach (var item in AdminList.admins)
                    {
                        if (item.Login == SearchedProductList.Login)
                        {
                            Admin tmp = item;

                            Console.Write("Enter password: ");
                            string paassword;

                            paassword = Console.ReadLine();

                            if (paassword == tmp.Paassword)
                            {
                                loop = false;
                                Console.WriteLine("Wellcome " + item.Login + "!");
                                AdminMenu.StartUp(admins.IndexOf(tmp));
                                break;
                                
                            }
                            else
                            {
                                Console.WriteLine("Password is not right");
                                Console.WriteLine("Try again");
                                break;
                            }


                        }
                        else
                        {
                            Console.WriteLine("Login is not right");
                            Console.WriteLine("Try again");
                            break;



                        }
                    }
                }
                else
                {
                    Console.WriteLine("Login is not right");
                    Console.WriteLine("Try again");


                }
            }

        }
    }
}
