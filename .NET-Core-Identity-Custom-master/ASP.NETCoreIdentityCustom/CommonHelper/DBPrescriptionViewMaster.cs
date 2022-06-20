using Clinic_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Clinic_Management_System.CommonHelper
{
    public class DBPrescriptionViewMaster
    {

        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_System; User Id=bhavesh; Password=bhavesh; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;
        public DBPrescriptionViewMaster()
        {
            con = new SqlConnection(connectionString);
            con.Open();

        }

        //This is prescription view there get data and pass to the controller....
        public List<PrescriptionModel> ViewPrescription(string orderby, string whereclause)
        {
            List<PrescriptionModel> ULst = new List<PrescriptionModel>();
            using (con)
            {
                cmd = new SqlCommand("ViewPrescription", con);
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PrescriptionModel U = new PrescriptionModel();
                    U.Presc_id = Convert.ToInt32(rdr["Presc_id"]);
                    U.Prescr_Date = rdr["Prescr_Date"].ToString();
                    U.PatientId = Convert.ToInt32(rdr["PatientId"]);
                    U.Firstname = rdr["Firstname"].ToString();
                    U.Lastname = rdr["Lastname"].ToString();
                    U.MedicineName = rdr["M_Name"].ToString();
                    U.Quantity = Convert.ToInt32(rdr["quantity"]);


                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }
    }
}
