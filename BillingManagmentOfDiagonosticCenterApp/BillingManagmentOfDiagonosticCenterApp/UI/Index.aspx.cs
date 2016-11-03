using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    public partial class Index : System.Web.UI.Page
    {
        UserManager _userManager=new UserManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Value;
            string password = passTextBox.Value;

            User user=new User(userName, password);

            string message = _userManager.IsMachedWithLogin(user);

            if (message == "UserName & Password Mached")
            {
                Session["UserName"] = userNameTextBox.Value;
                Response.Redirect("PatientInfoEntryUI.aspx");
            }
            else
            {
                loginFaildLabel.Text = "Login Faild!!";
            }
        }
    }
}