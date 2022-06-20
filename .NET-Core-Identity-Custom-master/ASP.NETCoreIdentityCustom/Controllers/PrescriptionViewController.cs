using Clinic_Management_System.CommonHelper;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class PrescriptionViewController : Controller
    {
        DBPrescriptionViewMaster DBPVM = new DBPrescriptionViewMaster();

        public IActionResult PrescriptionManagement()
        {
            return View();
        }

        //here method for view all prescription records
        [HttpGet]
        public JsonResult ViewPrescription(string orderby, string whereclause)
        {
            List<PrescriptionModel> ULst = new List<PrescriptionModel>();

            ULst = DBPVM.ViewPrescription(orderby, whereclause);

            return Json(new { data = ULst });
        }
    }
}
