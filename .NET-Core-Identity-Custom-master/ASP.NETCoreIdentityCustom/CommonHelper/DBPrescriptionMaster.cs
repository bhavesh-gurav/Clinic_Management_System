using Microsoft.Data.SqlClient;
using System.Data;

namespace Clinic_Management_System.CommonHelper
{
    public class DBPrescriptionMaster
    {

        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_System; User Id=bhavesh; Password=bhavesh; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;


        public DBPrescriptionMaster()
        {
            con = new SqlConnection(connectionString);
            con.Open();
        }

        //This method for adding new prescription....
        public void AddPrescription(PrescriptionModel model)
        {
            using (con)
            {
                SqlCommand cmd = new SqlCommand("AddPrescription", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy");
                cmd.Parameters.AddWithValue("@PatientId", model.PatientId);
                cmd.Parameters.AddWithValue("@MedicineName", model.MedicineName);
                cmd.Parameters.AddWithValue("@SoldQuantity", model.Quantity);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
