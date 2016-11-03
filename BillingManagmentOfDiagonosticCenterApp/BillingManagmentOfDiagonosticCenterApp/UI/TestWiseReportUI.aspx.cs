using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BillingManagmentOfDiagonosticCenterApp.BLL;
using BillingManagmentOfDiagonosticCenterApp.Model.ViewModels;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace BillingManagmentOfDiagonosticCenterApp.UI
{
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void showReportButton_Click(object sender, EventArgs e)
        {

            DateTime lowerDate = DateTime.Parse(lowerDateTextBox.Value.ToString());
            DateTime upperDate = DateTime.Parse(upperDateTextBox.Value.ToString());

            TestManager testManager = new TestManager();
            List<ViewTestWithTotalTest> viewTestWithTotalTestslList = testManager.GetTestWiseReportByDate(lowerDate, upperDate);
            testShowGridView.DataSource = viewTestWithTotalTestslList;
            testShowGridView.DataBind();

            ViewState["viewTestWithTotalTestslList"] = viewTestWithTotalTestslList;
            double totalAmount = 0;
            foreach (ViewTestWithTotalTest viewTestWithTotalTest in viewTestWithTotalTestslList)
            {
                totalAmount += viewTestWithTotalTest.TotalAmount;
            }

            totalTextBox.Value = totalAmount.ToString();
        }

        protected void logoutButton_OnClick(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Response.Redirect("Index.aspx");
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            List<ViewTestWithTotalTest> viewTestWithTotalTestslList = (List<ViewTestWithTotalTest>)ViewState["viewTestWithTotalTestslList"];

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append(
                        "<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Test Wise Report</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Office:Care Diagonostic Center</b>");
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br /> <br />");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    sb.Append("<th>");
                    sb.Append("SL No");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Test Name");
                    sb.Append("</th>");
                    sb.Append("<th>");
                    sb.Append("Total Test");
                    sb.Append("</th>");
                    sb.Append("<th align='center'>");
                    sb.Append("Total Amount");
                    sb.Append("</th>");
                    sb.Append("</tr>");
                    int count = 0;
                    double totalAmount = 0;
                    foreach (ViewTestWithTotalTest viewTestWithTotalTest in viewTestWithTotalTestslList)
                    {
                        sb.Append("<tr>");
                        sb.Append("<td>");
                        sb.Append(++count);
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(viewTestWithTotalTest.Name);
                        sb.Append("</td>");
                        sb.Append("<td>");
                        sb.Append(viewTestWithTotalTest.TotalTest);
                        sb.Append("</td>");
                        sb.Append("<td align='center'>");
                        sb.Append(viewTestWithTotalTest.TotalAmount);
                        sb.Append("</td>");
                        sb.Append("</tr>");
                        totalAmount += viewTestWithTotalTest.TotalAmount;
                    }
                    sb.Append("<tr><td align = 'right' colspan = '");
                    sb.Append("3'>Total</td>");
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
                    Response.AddHeader("content-disposition", "attachment;filename=TestWise_report" + DateTime.Now + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();

                }
            }
        }
    }
}