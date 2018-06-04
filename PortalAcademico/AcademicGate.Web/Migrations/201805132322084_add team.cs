namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addteam : DbMigration  
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisciplineId = c.Int(nullable: false),
                        Year = c.DateTime(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        Room = c.String(),
                        Time = c.DateTime(nullable: false),
                        Teacher_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Teacher_Id)
                .Index(t => t.DisciplineId)
                .Index(t => t.Teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "Teacher_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Teams", "DisciplineId", "dbo.Disciplines");
            DropIndex("dbo.Teams", new[] { "Teacher_Id" });
            DropIndex("dbo.Teams", new[] { "DisciplineId" });
            DropTable("dbo.Teams");
        }
    }
}
