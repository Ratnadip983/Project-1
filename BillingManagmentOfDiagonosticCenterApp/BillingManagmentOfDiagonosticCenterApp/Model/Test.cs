using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingManagmentOfDiagonosticCenterApp.Model
{
    [Serializable]
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Fee { get; set; }
        public int TypeId { get; set; }

        public Test()
        { }
        public Test(string name,double fee,int typeId)
        {
            this.Name = name;
            this.Fee = fee;
            this.TypeId = typeId;
        }

        public Test(int id,string name, double fee, int typeId):this(name,fee,typeId)
        {
            this.Id = id;
        }
    }
}