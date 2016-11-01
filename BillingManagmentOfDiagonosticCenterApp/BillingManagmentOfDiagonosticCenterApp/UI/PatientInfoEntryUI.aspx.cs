using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    
    public partial class PatientInfoEntryUI : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            testTypeDangerDiv.Visible = false;
            testTypeSuccessfullDiv.Visible = false;
            if (!IsPostBack)
            {
                LoadTestDropDownList();
            }
            FillAllTestOfPatient();

        }

        public void LoadTestDropDownList()
        {
            TestManager testManager = new TestManager();
            List<Test> testTypeList = testManager.GetAllTestsList();
            testSelectDropDownList.DataSource = testTypeList;
            testSelectDropDownList.DataTextField = "Name";
            testSelectDropDownList.DataValueField = "Id";
            testSelectDropDownList.DataBind();

        }

        protected void testSelectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TestManager testManager=new TestManager();
            int id = int.Parse(testSelectDropDownList.SelectedValue.ToString());
            feeTextBox.Value = testManager.GetFeeByTestId(id).ToString();
        }

        
        protected void addGridviewButton_Click(object sender, EventArgs e)
        {
            TestManager testManager=new TestManager();
            int id = int.Parse(testSelectDropDownList.SelectedValue.ToString());
            Test test = testManager.GetTestById(id);
            if (ViewState["TestList"] == null)
            {
                List<Test> testList = new List<Test>();
                testList.Add(test);
                ViewState["TestList"] = testList;
            }
            else
            {
                List<Test> testList =(List<Test>) ViewState["TestList"];
                testList.Add(test);
                ViewState["TestList"] = testList;
            }
            
            double totalAmount = Convert.ToDouble(ViewState["TotalAmount"]);
            totalAmount += double.Parse(feeTextBox.Value);
            ViewState["TotalAmount"] = totalAmount;
            totalTextBox.Value = totalAmount.ToString();

            FillAllTestOfPatient();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Value.Trim();
            DateTime dateBirth = DateTime.Parse(dateOfBirthTextBox.Value);
            double fee = double.Parse(feeTextBox.Value);
            string mobileNo = mobileTextBox.Value.ToString().Trim();

            DateTime currentDateTime=DateTime.Now;
            List<Test> testList = (List<Test>)ViewState["TestList"];
            if (testList.Count>0)
            {
                if (name != "" && mobileNo != "")
                {
                    PatientManager patientManager=new PatientManager();
                    BillManager billManager=new BillManager();
                    OrderManager orderManager=new OrderManager();
                    Patient patient=new Patient(name,mobileNo,dateBirth);

                    int patientRowAffected = patientManager.Save(patient);

                    int patientId = patientManager.GetLastPatientId();
                    double totalAmount = Convert.ToDouble(ViewState["TotalAmount"]);
                    string billNo = currentDateTime.ToString("yyyyMMddHHmmss") + patientId.ToString();

                    Bill bill=new Bill(billNo,currentDateTime,totalAmount,"unpaid");
                    int billRowAffected = billManager.Save(bill);

                    foreach (Test test in testList)
                    {
                        Order order = new Order(patientId, test.Id, billNo);
                        int orderRowAffected = orderManager.Save(order);
                    }

                    //if (patientRowAffected > 0 && billRowAffected > 0 && orderRowAffected > 0)
                    //{
                        testTypeSuccessfullAlartLabel.Text = "All Test are successfully saved!!";
                        testTypeSuccessfullDiv.Visible = true;
                        testTypeDangerDiv.Visible = false;
                    //}

                }
                else
                {
                    testTypeDangerAlartLabel.Text = "Patient name and mobile number must required!!";
                    testTypeDangerDiv.Visible = true;
                    testTypeSuccessfullDiv.Visible = false;
                }
            }
            else
            {
                testTypeDangerAlartLabel.Text = "No Test is added!!";
                testTypeDangerDiv.Visible = true;
                testTypeSuccessfullDiv.Visible = false;
            }
            
        }

        public void FillAllTestOfPatient()
        {
            if (ViewState["TestList"] != null)
            {
                List<Test> testList = (List<Test>)ViewState["TestList"];
                testShowGridView.DataSource = testList;
                testShowGridView.DataBind();
            }
        }
    }
}