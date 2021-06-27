using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class RegisteredUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public readonly string Status = "User";
        public  List<Order> OrderList;
        public RegisteredUser(string Login, string Password)
        {
            this.Password = Password;
            this.Login = Login;
            this.OrderList = new List<Order>();
        }

        public void ChangeLogin(string Login)
        {
            this.Login = Login;
        }
        public void ChangePassword(string Password)
        {
            this.Password = Password;


        }
        



        public void ShowOrderList()
        {
            foreach (var item in OrderList)
            {
                Console.WriteLine("------------------------------------");
                Console.Write($"ID: {item.ID}\nStatus: {item.Status}\nNameUser: {item.NameUser}\nCity: {item.City}\nProductList:\n");
                item.PrintProductList();
                Console.WriteLine("------------------------------------");
            }
            
        }

    }
}
