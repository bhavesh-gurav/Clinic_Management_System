using Clinic_Management_System.CommonHelper;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class PatientController : Controller
    {
        DBPatientMaster DBPM = new DBPatientMaster();

        public IActionResult PatientDashboard()
        {
            return View();
        }

        public IActionResult AddPatient()
        {
            return View();
        }


        // Method for Adding Data
        [HttpPost]
        public JsonResult AddPatient([FromBody] PatientModel model)
        {
            {
                DBPM.AddPatient1(model);
            }
            return Json(View(model));
        }

        // Method To All Get Data
        [HttpGet]
        public JsonResult GetAllPatientData(string orderby, string whereclause)
        {
            List<PatientModel> ULst = new List<PatientModel>();

            ULst = DBPM.GetPatientData(orderby, whereclause);

            return Json(new { data = ULst });
        }

        // Method To Update Record
        [HttpPost]
        public JsonResult UpdateUserStatus([FromBody] PatientModel UM)
        {
            DBPM.UpdateStatus(UM);
            return Json(new { data = UM });
        }

        //Method To Get Data in Dropdown List
        [HttpGet]
        public JsonResult GetDropdownMedicine(string orderby, string whereclause)
        {
            List<MedicineModel> UList = new List<MedicineModel>();
            UList = DBPM.GetMedicineData(orderby, whereclause);
            return Json(new { data = UList });
        }


    }
}
