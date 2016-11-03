using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public User(string email, string password)
        {
            this.UserName = email;
            this.Password = password;
        }
    }
}