using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AcademicGate.Web.Models
{
    public class AcademicCalendar
    {
        public int Id { get; set; }

        [Display(Name ="Início do Semestre")]
        public DateTime BegingSemestre { get; set; }

        [Display(Name ="Periodo de Provas")]
        public string ProofPeriod { get; set; }

        [Display(Name ="Limite de Lançamento de Notas")]
        public DateTime LimitThrowProof { get; set; }

        [Display(Name ="Férias")]
        public DateTime Vacation { get; set; }

        [Display(Name ="Periodo de Matricula")]
        public DateTime MatriculePeriod { get; set; }

        [Display(Name ="Data de Lieração do Boletim")]
        public DateTime ReleaseReportCard { get; set; }

        [Display(Name ="Feriados")]
        public List<DateTime> Vacations { get; set; }   
    }
}