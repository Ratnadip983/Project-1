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
    public partial class TestTypeEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            testTypeDangerDiv.Visible = false;
            testTypeSuccessfullDiv.Visible = false;
            FillAllType();
        }
        protected void testTypeSaveButton_Click(object sender, EventArgs e)
        {
            TestTypeManager testTypeManager=new TestTypeManager();
            string name = testTypeNameTextBox.Value.Trim();
            if (name != "")
            {
                TestType testType = new TestType(name);

                if (!testTypeManager.IsTestTypeExist(testType))
                {
                    int rowAffected = testTypeManager.Save(testType);
                    if (rowAffected > 0)
                    {
                        testTypeSuccessfullAlartLabel.Text = "Test testType succesfully saved.";
                        testTypeDangerDiv.Visible = false;
                        testTypeSuccessfullDiv.Visible = true;
                        FillAllType();
                    }
                    else
                    {
                        testTypeDangerAlartLabel.Text = "Test Type Name not saved!";
                        testTypeDangerDiv.Visible = true;
                        testTypeSuccessfullDiv.Visible = false;
                    }
                }
                else
                {
                    testTypeDangerAlartLabel.Text = "Test Type already exist";
                    testTypeDangerDiv.Visible = true;
                    testTypeSuccessfullDiv.Visible = false;
                }

            }
            else
            {
                testTypeDangerAlartLabel.Text = "Please, give type name.";
                testTypeDangerDiv.Visible = true;
                testTypeSuccessfullDiv.Visible = false;
            }
        }

        private void FillAllType()
        {
            TestTypeManager testTypeManager=new TestTypeManager();
            List<TestType> testTypeList = testTypeManager.GetAllTypesList();

            testTypeShowGridView.DataSource = testTypeList;
            testTypeShowGridView.DataBind();
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Response.Redirect("Index.aspx");
        }
    }
}