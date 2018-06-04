using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademicGate.Web.Models
{
    public class Team
    {
        public int Id { get; set; }

        public int DisciplineId { get; set; }     
        public Discipline Discipline { get; set; }

        [StringLength(50)]
        public string Name { get; set; }    

        [Display(Name ="Ano")]
        public DateTime Year { get; set; }
            
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }   

        [Display(Name ="Sala")]
        public string Room { get; set; }

        [Display(Name ="Hora")]
        public DateTime Time { get; set; }

        public List<ApplicationUser> Students { get; set; }
    }
}