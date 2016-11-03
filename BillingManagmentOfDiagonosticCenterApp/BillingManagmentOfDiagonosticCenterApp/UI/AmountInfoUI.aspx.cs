using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    public partial class AmountInfoUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            testTypeDangerDiv.Visible = false;
        }

        protected void amountSearchButton_Click(object sender, EventArgs e)
        {
            string billNo = billNoTextBox.Value.Trim();
            string mobileNo = mobileNoTextBox.Value.Trim();
            if (billNo != "" || mobileNo != "")
            {
                BillManager billManager = new BillManager();
                Bill bill;
                if (billNo != String.Empty)
                {
                    bill = billManager.GetBillByBillNo(billNo);
                }
                else
                {
                    bill = billManager.GetBillByMobileNo(mobileNo);
                }

                if (bill == null)
                {
                    testTypeDangerAlartLabel.Text = "Not Found!!";
                    testTypeDangerDiv.Visible = true;
                }
                else
                {
                    amountTextBox.Value = bill.Amount.ToString();
                    dueDateTextBox.Value = bill.Date.Date.ToString("dd/MM/yyyy");

                    ViewState["BillNo"] = bill.BillNo;
                }
            }
            else
            {
                testTypeDangerAlartLabel.Text = "Please enter either Bill No or Mobile No!!";
                testTypeDangerDiv.Visible = true;
            }
        }

        protected void dueAmountPayButton_Click(object sender, EventArgs e)
        {
            BillManager billManager=new BillManager();
            string amount = amountTextBox.Value.ToString().Trim();
            if (amount != "")
            {
                string billNo = ViewState["BillNo"].ToString();
                bool isPaid = billManager.IsBillPaid(billNo);
                if (isPaid == true)
                {
                    testTypeSuccessfullAlartLabel.Text = "Bill already Paid.";

                    testTypeSuccessfullDiv.Visible = true;
                }
                else
                {
                    int rowAffected = billManager.UpdateBillStatus(billNo);

                    if (rowAffected > 0)
                    {
                        testTypeSuccessfullAlartLabel.Text = "Bill Successfully paid.";

                        testTypeSuccessfullDiv.Visible = true;
                    }
                }
                

            }
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Response.Redirect("Index.aspx");
        }
    }
}