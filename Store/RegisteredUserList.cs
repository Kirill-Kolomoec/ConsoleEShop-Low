using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Store
{
    class RegisteredUserList
    {
        static List<RegisteredUser> users = new List<RegisteredUser>();

        public static RegisteredUser GetUser(int index) => users[index];

        public static void Print()
        {
            int n = 0;
            foreach (var item in users)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"{n}. {item.Login}");
                Console.WriteLine("-------------------------------");
                n++;
            }


        }
        public static void FillList() => users.Add(new RegisteredUser("kirill", "cool"));

        public static void EditUser(int index)
        {
            
            Console.Write("Enter new login: ");

            users[index].Login = Console.ReadLine();

            Console.Write("Enter new password: ");

            users[index].Password = Console.ReadLine();
            Console.Write("User has been edited: ");

        }

        public static void Registration()
        {
            bool passEquels = false;
            string login, pass1, pass2;
           
            Console.Write("\nRegistration: ");
            while (passEquels!=true)
            {

                Console.Write("\nEnter login: ");
                login = Console.ReadLine();
                Console.Write("\nEnter password: ");
                pass1 = Console.ReadLine();
                Console.Write("\nRepeat password: ");
                pass2 = Console.ReadLine();
                if (pass1 != pass2)
                {
                    Console.Write("\nPasswords are not equel. Please try again.\n");
                }
                else
                {
                    passEquels = true;

                    users.Add(new RegisteredUser(login, pass1));


                    Console.Write("\nYou have been registered. Please log in system.\n");
                }
            }            


        }


        public static void FindRegisteredUser()
        {
            bool loop = true;
            bool idFound = false;
            while (loop)
            {
                string search;
                Console.Write("\nEnter login: ");
                search = Console.ReadLine();

                RegisteredUser SearchedUser = users.FirstOrDefault(s => s.Login == search);
                
                if (SearchedUser!= null)
                {
                    foreach (var item in RegisteredUserList.users)
                    {
                        if (item.Login == SearchedUser.Login)
                        {
                            RegisteredUser tmp = item;

                            Console.Write("Enter password: ");
                            string paassword;

                            paassword = Console.ReadLine();

                            if (paassword == tmp.Password)
                            {
                                idFound = true;
                                loop = false;
                                Console.WriteLine("Wellcome " + item.Login + "!");
                                Thread.Sleep(3000);

                                UserMenu.StartUp(users.IndexOf(tmp));
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Password is not right");
                                Console.WriteLine("Try again");
                                break;
                            }


                        }
                        
                    }

                    if (idFound==false)
                    {
                        Console.WriteLine("There is not such user");
                        
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
