namespace AcademicGate.Web.Models
{
    public class NotesStudentTeamViewModel
    {
        public NotesStudentTeamViewModel()
        {
            AP1 = 0.00;
            AP2 = 0.00;
        }

        public string StudentName { get; set; }

        public int TeamId { get; set; }

        public double AP1 { get; set; }
        public double AP2 { get; set; }
    }
}