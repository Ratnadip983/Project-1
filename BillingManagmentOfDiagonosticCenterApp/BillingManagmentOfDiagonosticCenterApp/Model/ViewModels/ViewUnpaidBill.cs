using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model.ViewModels
{
    [Serializable]
    public class ViewUnpaidBill
    {
        public string BillNo { get; set; }
        public string ContactNo { get; set; }
        public string PatientName { get; set; }
        public double BillAmount { get; set; }
    }
}