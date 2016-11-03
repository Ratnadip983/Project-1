using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model;
using BillingManagmentOfDiagonosticCenterApp.Model.ViewModels;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    public partial class TestEntryUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dangerDiv.Visible = false;
            successfullDiv.Visible = false;
            
            if (!IsPostBack)
            {
                LoadTestTypeDropDownList();
                FillAllTestWithType();
            }

            
        }

        public void LoadTestTypeDropDownList()
        {
            TestTypeManager testTypeManager=new TestTypeManager();
            List<TestType> testTypeList = testTypeManager.GetAllTypesList();
            testTypeSelectDropDownList.DataSource = testTypeList;
            testTypeSelectDropDownList.DataTextField = "Name";
            testTypeSelectDropDownList.DataValueField = "Id";
            testTypeSelectDropDownList.DataBind();

        }

        protected void testsSaveButton_Click(object sender, EventArgs e)
        {
            if (testNameTextBox.Text.Trim() != "" && testFeeTextBox.Text.Trim() != "")
            {
                double testFee;
                bool isDouble = Double.TryParse(testFeeTextBox.Text.Trim(), out testFee);
                if (isDouble)
                {
                    TestManager testManager = new TestManager();
                    string testName = testNameTextBox.Text.Trim();

                    int typeId = int.Parse(testTypeSelectDropDownList.SelectedValue);

                    Test test = new Test(testName, testFee, typeId);
                    if (!testManager.IsTestExist(test))
                    {
                        int rowAffected = testManager.Save(test);

                        if (rowAffected > 0)
                        {
                            successfullAlartLabel.Text = "Successfully Saved!!";
                            dangerDiv.Visible = false;
                            successfullDiv.Visible = true;
                            FillAllTestWithType();
                        }
                        else
                        {
                            dangerAlartLabel.Text = "Test Entry Failed!!";
                            dangerDiv.Visible = true;
                            successfullDiv.Visible = false;
                        }
                    }
                    else
                    {
                        dangerAlartLabel.Text = "Test Entry is exist!!";
                        dangerDiv.Visible = true;
                        successfullDiv.Visible = false;
                    }
                    
                }
                else
                {
                    dangerAlartLabel.Text = "Please, Enter numeric value as fee";
                    dangerDiv.Visible = true;
                    successfullDiv.Visible = false;
                }
                

            }
            else
            {
                dangerAlartLabel.Text = "Please, Input required for all field.";
                dangerDiv.Visible = true;
                successfullDiv.Visible = false;
            }
            


        }

        private void FillAllTestWithType()
        {
            TestManager testManager = new TestManager();
            List<ViewAllTestWithType> testListWithType = testManager.GetAllTypesListWithType();

            testShowGridView.DataSource = testListWithType;
            testShowGridView.DataBind();
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Response.Redirect("Index.aspx");
        }
    }
}