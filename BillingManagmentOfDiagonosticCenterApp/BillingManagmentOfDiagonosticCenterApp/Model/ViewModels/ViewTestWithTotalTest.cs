using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model.ViewModels
{
    [Serializable]
    public class ViewTestWithTotalTest
    {
        public string Name { get; set; }
        public int TotalTest { get; set; }
        public double TotalAmount { get; set; }
    }
}