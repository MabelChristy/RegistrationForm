using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Microsoft.Reporting.WebForms;

namespace RegistrationForm
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadReport();
            }
        }

        private void LoadReport()
        {
            // Find ReportViewer inside ContentPlaceHolder
            ReportViewer reportViewer = (ReportViewer)Master.FindControl("ContentPlaceHolder1").FindControl("ReportViewer1");

            if (reportViewer != null)
            {
                string connString = "your_connection_string_here"; // Replace with actual DB connection string
                string query = "SELECT M_NO, Name, DOB, Address, PAN, Aadhar FROM Users"; // Adjust table name if needed

                using (SqlConnection conn = new SqlConnection(connString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    reportViewer.LocalReport.DataSources.Clear();
                    ReportDataSource rds = new ReportDataSource("UserDataSet", dt);
                    reportViewer.LocalReport.DataSources.Add(rds);
                    reportViewer.LocalReport.ReportPath = Server.MapPath("~/UserReport.rdlc");
                    reportViewer.LocalReport.Refresh();
                }
            }
            else
            {
                throw new Exception("ReportViewer1 not found.");
            }
        }
    }
}
    