using Clinic_Management_System.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Clinic_Management_System.CommonHelper
{
    public class DBMedicineMaster
    {
        //This is connection string provide in hard way....
        string connectionString = "Server=192.168.1.250\\SQL2019INT; Database=CMS_System; User Id=bhavesh; Password=bhavesh; Trusted_Connection=false; MultipleActiveResultSets=true";

        //Set the connection class...
        SqlConnection con = null;
        SqlCommand cmd = null;

        //Build constructor for connection string...
        public DBMedicineMaster()
        {
            con = new SqlConnection(connectionString);
            con.Open();

        }

        //Adding New Medicine in table....
        public int AddMedicine(MedicineModel model)
        {
            if (model.M_Id == 0)
            {
                using (con)
                {
                    SqlCommand cmd = new SqlCommand("M_AddAndUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@M_Name", model.M_Name);
                    cmd.Parameters.AddWithValue("@M_Manufacturer", model.M_Manufacturer);
                    cmd.Parameters.AddWithValue("@M_Price", model.M_Price);
                    cmd.Parameters.AddWithValue("@M_Date", model.M_Date);
                    cmd.Parameters.AddWithValue("@Stock", model.Stock);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //above condition will false the else excuted.... for update....
            else
            {
                using (con)
                {
                    cmd = new SqlCommand("M_AddAndUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@M_Id", SqlDbType.VarChar).Value = model.M_Id;
                    cmd.Parameters.AddWithValue("@M_Name", SqlDbType.VarChar).Value = model.M_Name;
                    cmd.Parameters.AddWithValue("@M_Manufacturer", SqlDbType.VarChar).Value = model.M_Manufacturer;
                    cmd.Parameters.AddWithValue("@M_Price", SqlDbType.VarChar).Value = model.M_Price;
                    cmd.Parameters.AddWithValue("@M_Date", SqlDbType.VarChar).Value = model.M_Date;
                    cmd.Parameters.AddWithValue("@Stock", SqlDbType.VarChar).Value = model.Stock;

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }

        //Get medicine record in table.....
        public List<MedicineModel> GetMedicineData(string orderby, string whereclause)
        {
            List<MedicineModel> ULst = new List<MedicineModel>();
            using (con)
            {
                cmd = new SqlCommand("M_GetMedicineRecords", con);
                cmd.Parameters.AddWithValue("@orderby", SqlDbType.VarChar).Value = orderby;
                cmd.Parameters.AddWithValue("@whereclause", SqlDbType.VarChar).Value = whereclause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    MedicineModel U = new MedicineModel();
                    U.M_Id = Convert.ToInt32(rdr["M_Id"]);
                    U.M_Name = rdr["M_Name"].ToString();
                    U.M_Manufacturer = rdr["M_Manufacturer"].ToString();
                    U.M_Price = Convert.ToInt32(rdr["M_Price"]);
                    U.M_Date = rdr["M_Date"].ToString();
                    U.Stock = Convert.ToInt32(rdr["Stock"]);

                    ULst.Add(U);
                }
                con.Close();
            }
            return ULst;
        }


        //Delete medicine from database....
        public int DeleteRecord(MedicineModel model)
        {
            if (model.M_Id != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("DeleteMedicineRecord", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@M_Id", SqlDbType.Int).Value = model.M_Id;
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            return 1;
        }


    }
}
