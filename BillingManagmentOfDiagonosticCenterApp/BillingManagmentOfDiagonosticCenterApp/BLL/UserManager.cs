using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.DAL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.BLL
{
    public class UserManager
    {
        UserGateway _userGateway=new UserGateway();

        public string IsMachedWithLogin(User user)
        {
            if (_userGateway.GetMachResultFromUser(user) == true)
            {
                return "UserName & Password Mached";
            }
            else
            {
                return "Login Failed!!";
            }
        }
    }
}