using Clinic_Management_System.CommonHelper;
using Clinic_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class MedicineController : Controller
    {
        DBMedicineMaster DBMM = new DBMedicineMaster();

        public IActionResult MedicineManage()
        {
            return View();
        }

        public IActionResult AddMedicine()
        {
            return View();
        }

        // Add Medicine Function
        [HttpPost]
        public JsonResult AddMedicine([FromBody] MedicineModel model)
        {
            {
                DBMM.AddMedicine(model);
            }
            return Json(View(model));
        }

        //Get Madicine In table
        [HttpGet]
        public JsonResult MedicineManage1(string orderby, string whereclause)
        {
            List<MedicineModel> ULst = new List<MedicineModel>();
            ULst = DBMM.GetMedicineData(orderby, whereclause);
            return Json(new { data = ULst });
        }

        // This method to Delete record....
        [HttpPost]
        public JsonResult DeleteMedicine([FromBody] MedicineModel UM)
        {
            DBMM.DeleteRecord(UM);
            return Json(new { data = UM });
        }
    }
}
