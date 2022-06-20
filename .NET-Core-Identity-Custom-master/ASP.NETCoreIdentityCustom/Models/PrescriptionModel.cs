using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic_Management_System.CommonHelper
{
    public class PrescriptionModel
    {
        [Key]
        public int Presc_id { get; set; }

        [ForeignKey("PatientModel")]
        public int PatientId { get; set; }

        [Required]
        public string? Prescr_Date { get; set; }

        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }

        [Required]
        public string? MedicineName { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public int? Price { get; set; }

    }
}
