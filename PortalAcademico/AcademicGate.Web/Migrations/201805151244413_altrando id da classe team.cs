namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class altrandoiddaclasseteam : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Teams", new[] { "Teacher_Id" });
            DropColumn("dbo.Teams", "ApplicationUserId");
            RenameColumn(table: "dbo.Teams", name: "Teacher_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Teams", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Teams", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Teams", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Teams", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Teams", name: "ApplicationUserId", newName: "Teacher_Id");
            AddColumn("dbo.Teams", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teams", "Teacher_Id");
        }
    }
}
