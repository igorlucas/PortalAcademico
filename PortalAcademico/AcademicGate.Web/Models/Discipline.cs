using System.ComponentModel.DataAnnotations;

namespace AcademicGate.Web.Models
{
    public class Discipline
    {
        public int Id { get; set; }

        [Display(Name="Nome")]
        [StringLength(80)]
        public string Name { get; set; }
        
        [Display(Name="Ementa")]
        public string Menu { get; set; }    
    }
}