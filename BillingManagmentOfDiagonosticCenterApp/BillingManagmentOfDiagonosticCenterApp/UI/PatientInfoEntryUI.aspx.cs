using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    
    public partial class PatientInfoEntryUI : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                successLabel.Text = "Welcome " + Session["UserName"].ToString();
               
            }

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
                //if (!IsTestExistInList(test))
                //{
                    testList.Add(test);
                    ViewState["TestList"] = testList;
                //}
                //else
                //{
                //    testTypeDangerAlartLabel.Text = "This test is already added!!";
                //    testTypeDangerDiv.Visible = true;
                //    testTypeSuccessfullDiv.Visible = false;
                //}
            }
            
            double totalAmount = Convert.ToDouble(ViewState["TotalAmount"]);
            //if (!IsTestExistInList(test))
            //{
                totalAmount += double.Parse(feeTextBox.Value);
            //}
            ViewState["TotalAmount"] = totalAmount;
            totalTextBox.Value = totalAmount.ToString();

            FillAllTestOfPatient();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Value;
            DateTime dateBirth = DateTime.Parse(dateOfBirthTextBox.Value);
            double fee = double.Parse(feeTextBox.Value);
            string mobileNo = mobileTextBox.Value.ToString();

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
                    GetReportInPdf(name, mobileNo, billNo, dateBirth);
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

        protected void logoutButton_Click(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Response.Redirect("Index.aspx");
        }

        public bool IsTestExistInList(Test test)
        {
            bool isExist = false;
            List<Test> testList = (List<Test>) ViewState["TestList"];
            foreach (Test testofList in testList)
            {
                if (test.Id==testofList.Id)
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;

        }

        public void GetReportInPdf(string name, string mobileNo, string billNo, DateTime dateOfBirth)
        {
            List<Test> testList = (List<Test>)ViewState["TestList"];

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append(
                        "<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Patient Test Report</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Office:Care Diagonostic Center</b>");
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td>Bill No: ");
                    sb.Append(billNo);
                    sb.Append("</td></tr></br>");
                    sb.Append("<tr><td>Patient Name: ");
                    sb.Append(name);
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td>Date of Birth: ");
                    sb.Append(dateOfBirth.ToString("yyyy-MM-dd"));
                    sb.Append("</td></tr>");
                    sb.Append("<tr><td>Mobile No: ");
                    sb.Append(mobileNo);
                    sb.Append("</td></tr></br>");
                    sb.Append("</table>");
                    sb.Append("<br /> <br /><br/><br/>");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr><td colspan='3' align='center'>Test Details</td></tr>");
                    sb.Append("<tr>");
                    sb.Append("<th>");
                    sb.Append("SL No");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Test Name");
                    sb.Append("</th>");
                    sb.Append("<th align='center'>");
                    sb.Append("Fee");
                    sb.Append("</th>");
                    sb.Append("</tr>");
                    int count = 0;
                    double totalAmount = 0;


                    foreach (Test test in testList)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(++count);
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(test.Name);
                        sb.Append("</td>");
                        sb.Append("<td align='center'>");
                        sb.Append(test.Fee);
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        totalAmount += test.Fee;
                    }
                    sb.Append("<tr><td align = 'right' colspan = '");
                    sb.Append("2'>Total</td>");
                    sb.Append("<td align='center'><b>");
                    sb.Append(totalAmount);
                    sb.Append("</b></td>");
                    sb.Append("</tr></table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Patient_report" + DateTime.Now + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();

                }
            }
        }
    }
}