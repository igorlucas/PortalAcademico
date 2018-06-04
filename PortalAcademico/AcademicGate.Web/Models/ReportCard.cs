using System.Collections.Generic;

namespace AcademicGate.Web.Models
{
    public class ReportCard
    {
        public int Id { get; set; }

        public int StudentId { get; set; }  
        public ApplicationUser Student { get; set; }

        public List<RegistrationStudentTeam> NotesStudentTeam { get; set; }

        public ReportCard()
        {
            NotesStudentTeam = new List<RegistrationStudentTeam>();
        }
    }
}