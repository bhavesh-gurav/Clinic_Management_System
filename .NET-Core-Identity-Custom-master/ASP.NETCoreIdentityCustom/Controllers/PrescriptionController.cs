using Clinic_Management_System.CommonHelper;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    public class PrescriptionController : Controller
    {
        DBPrescriptionMaster DBPM = new DBPrescriptionMaster();

        public IActionResult AddPrescription()
        {
            return View();
        }

        //Adding prescription Method call from patientDashboard Function
        [HttpPost]
        public JsonResult AddPrescription([FromBody] PrescriptionModel model)
        {
            {
                DBPM.AddPrescription(model);

            }
            return Json(View(model));
        }
    }
}
