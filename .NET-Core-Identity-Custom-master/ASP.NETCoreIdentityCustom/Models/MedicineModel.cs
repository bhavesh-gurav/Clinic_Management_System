using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class MedicineModel
    {

        [Key]
        public int M_Id { get; set; }

        [Required]
        public string? M_Name { get; set; }

        [Required]
        public string? M_Manufacturer { get; set; }

        [Required]
        public int M_Price { get; set; }

        [Required]
        public string? M_Date { get; set; }

        [Required]
        public int Stock { get; set; }

    }
}
