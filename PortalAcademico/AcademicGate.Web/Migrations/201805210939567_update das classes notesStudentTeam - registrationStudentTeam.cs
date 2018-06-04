namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedasclassesnotesStudentTeamregistrationStudentTeam : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NotesStudentTeams", newName: "RegistrationStudentTeams");
            AddColumn("dbo.RegistrationStudentTeams", "Serie", c => c.String(maxLength: 20));
            AlterColumn("dbo.Disciplines", "Name", c => c.String(maxLength: 80));
            DropColumn("dbo.Disciplines", "Serie");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disciplines", "Serie", c => c.String());
            AlterColumn("dbo.Disciplines", "Name", c => c.String());
            DropColumn("dbo.RegistrationStudentTeams", "Serie");
            RenameTable(name: "dbo.RegistrationStudentTeams", newName: "NotesStudentTeams");
        }
    }
}
