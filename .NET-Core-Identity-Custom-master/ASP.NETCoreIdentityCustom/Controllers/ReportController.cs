using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Clinic_Management_System.Controllers
{
    public class ReportController : Controller
    {
        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_System; User Id=bhavesh; Password=bhavesh; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;

        //DBReportMaster RDBA = new DBReportMaster();

        public IActionResult PrescriptionReport()
        {
            return View();
        }

        //This method called for printing report on the base of date.....
        [HttpPost]
        public IActionResult PrescriptionReport(string startDate, string endDate)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetReport", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    cmd.Parameters.AddWithValue("@From", Convert.ToString(startDate));
                    cmd.Parameters.AddWithValue("@To", Convert.ToString(endDate));
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ViewBag.Data = dt;
                }
            }
            return View();
        }
    }
}
