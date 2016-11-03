using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.DAL
{
    public class UserGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["DiagnosticCenterManagementDBConnectionString"].ConnectionString;

        public bool GetMachResultFromUser(User user)
        {
            SqlConnection connection=new SqlConnection(connectionString);

            string query= "SELECT * FROM Users WHERE UserName='"+user.UserName+"' AND Password='"+user.Password+"' ";

            SqlCommand command=new SqlCommand(query, connection);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}