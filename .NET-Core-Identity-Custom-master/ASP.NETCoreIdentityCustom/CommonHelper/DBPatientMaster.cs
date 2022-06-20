using Clinic_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Clinic_Management_System.CommonHelper
{
    public class DBPatientMaster
    {

        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_System; User Id=bhavesh; Password=bhavesh; Trusted_Connection=false; MultipleActiveResultSets=true";

        SqlConnection con = null;
        SqlCommand cmd = null;
        public DBPatientMaster()
        {
            con = new SqlConnection(connectionString);
            con.Open();

        }

        //This Method help to add new Patient in database....
        public int AddPatient1(PatientModel model)
        {
            if (model.PatientId == 0)
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("P_AddAndUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", model.Firstname);
                    cmd.Parameters.AddWithValue("@LastName", model.Lastname);
                    cmd.Parameters.AddWithValue("@EmailId", model.EmailID);
                    cmd.Parameters.AddWithValue("@Address", model.Address);
                    cmd.Parameters.AddWithValue("@symptoms", model.Symptoms);
                    cmd.Parameters.AddWithValue("@ContactNo", model.ContactNo);
                    cmd.Parameters.AddWithValue("@IsFollowUp", 'N');
                    cmd.Parameters.AddWithValue("@Status", 'Y');

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            // And the condition will not is false then updation will applied.....
            else
            {
                using (con)
                {
                    cmd = new SqlCommand("P_AddAndUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@PatientId", SqlDbType.VarChar).Value = model.PatientId;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@Firstname", SqlDbType.VarChar).Value = model.Firstname;
                    cmd.Parameters.AddWithValue("@Lastname", SqlDbType.VarChar).Value = model.Lastname;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = model.EmailID;
                    cmd.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
                    cmd.Parameters.AddWithValue("@symptoms", SqlDbType.VarChar).Value = model.Symptoms;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = model.ContactNo;
                    cmd.Parameters.AddWithValue("@IsFollowUp", SqlDbType.VarChar).Value = model.IsFollowUp;

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

        //here get patient data and pass to controller....
        public List<PatientModel> GetPatientData(string orderby, string whereclause)
        {
            List<PatientModel> ULst = new List<PatientModel>();
            using (con)
            {
                cmd = new SqlCommand("GetPatientRecords", con);
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PatientModel U = new PatientModel();
                    U.PatientId = Convert.ToInt32(rdr["PatientId"]);
                    U.Firstname = rdr["Firstname"].ToString();
                    U.Lastname = rdr["Lastname"].ToString();
                    U.EmailID = rdr["EmailId"].ToString();
                    U.Address = rdr["Address"].ToString();
                    U.ContactNo = rdr["ContactNo"].ToString();
                    U.Symptoms = rdr["Symptoms"].ToString();
                    U.IsFollowUp = Convert.ToChar(rdr["IsFollowUp"]);
                    U.Status = Convert.ToChar(rdr["Status"]);

                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }

        //There is method for update status of patient....
        public int UpdateStatus(PatientModel model)
        {
            if (model.PatientId != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdatePatientStatus_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PatientId", SqlDbType.Int).Value = model.PatientId;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = model.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return 1;
        }

        //This method for getting meditcine in prescription.....
        public List<MedicineModel> GetMedicineData(string orderby, string whereclause)
        {
            List<MedicineModel> list = new List<MedicineModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                cmd = new SqlCommand("GetMedicine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("whereclause", SqlDbType.VarChar).Value = whereclause;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    MedicineModel M = new MedicineModel();
                    M.M_Id = Convert.ToInt32(sdr["M_Id"]);
                    M.M_Name = sdr["M_Name"].ToString();
                    M.Stock = Convert.ToInt32(sdr["Stock"]);
                    list.Add(M);

                }
                con.Close();

            }
            return list;
        }

    }
}
