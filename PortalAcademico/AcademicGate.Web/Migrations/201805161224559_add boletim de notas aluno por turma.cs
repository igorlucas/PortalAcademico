namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addboletimdenotasalunoporturma : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teams", name: "TeacherId", newName: "UserId");
            RenameIndex(table: "dbo.Teams", name: "IX_TeacherId", newName: "IX_UserId");
            CreateTable(
                "dbo.NotesStudentTeams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        TeamId = c.Int(nullable: false),
                        AP1 = c.Double(nullable: false),
                        AP2 = c.Double(nullable: false),
                        ReportCard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportCards", t => t.ReportCard_Id)
                .Index(t => t.ReportCard_Id);
            
            CreateTable(
                "dbo.ReportCards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            AddColumn("dbo.AspNetUsers", "Team_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Team_Id");
            AddForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.ReportCards", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NotesStudentTeams", "ReportCard_Id", "dbo.ReportCards");
            DropIndex("dbo.AspNetUsers", new[] { "Team_Id" });
            DropIndex("dbo.ReportCards", new[] { "Student_Id" });
            DropIndex("dbo.NotesStudentTeams", new[] { "ReportCard_Id" });
            DropColumn("dbo.AspNetUsers", "Team_Id");
            DropTable("dbo.ReportCards");
            DropTable("dbo.NotesStudentTeams");
            RenameIndex(table: "dbo.Teams", name: "IX_UserId", newName: "IX_TeacherId");
            RenameColumn(table: "dbo.Teams", name: "UserId", newName: "TeacherId");
        }
    }
}
