using System;

namespace AcademicGate.Web.Models
{
    public class Frequence
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int TeamId { get; set; }
        public DateTime Date { get; set; }
        public bool Presence { get; set; }  
    }
}