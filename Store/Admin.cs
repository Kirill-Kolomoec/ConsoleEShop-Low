using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Admin
    {
        public string Login { get; set; }
        public string Paassword { get; set; }
        public readonly string Status = "Admin";
        public Admin(string Login, string Paassword)
        {
            this.Paassword = Paassword;
            this.Login = Login;
        }
    }
}
