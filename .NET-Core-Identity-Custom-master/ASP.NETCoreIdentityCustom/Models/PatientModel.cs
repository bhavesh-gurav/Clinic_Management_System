using System.ComponentModel.DataAnnotations;

namespace Clinic_Management_System.Models
{
    public class PatientModel
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string? CreatedAt { get; set; }
        public string? EditedAt { get; set; }
        public string? DeletedAt { get; set; }


        [Required]
        public string? Firstname { get; set; }
        [Required]
        public string? Lastname { get; set; }
        [Required]
        public string? EmailID { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Symptoms { get; set; }
        [Required]
        public string? ContactNo { get; set; }
        [Required]
        public char? IsFollowUp { get; set; }
        [Required]
        public char? Status { get; set; }
    }
}
