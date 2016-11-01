using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model.ViewModels
{
    [Serializable]
    public class ViewAllTestWithType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fee { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}