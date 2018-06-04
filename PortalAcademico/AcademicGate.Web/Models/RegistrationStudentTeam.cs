using System.ComponentModel.DataAnnotations;

namespace AcademicGate.Web.Models
{
    public class RegistrationStudentTeam
    {
        public int Id { get; set; }

        public string StudentId { get; set; }
        public int TeamId { get; set; }

        [Display(Name = "Serie")]
        [StringLength(20)]
        public string Serie { get; set; }

        public double AP1 { get; set; }
        public double AP2 { get; set; } 
    }
}