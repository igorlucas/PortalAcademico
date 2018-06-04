namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterandoiddaclasseteam : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teams", name: "ApplicationUserId", newName: "TeacherId");
            RenameIndex(table: "dbo.Teams", name: "IX_ApplicationUserId", newName: "IX_TeacherId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teams", name: "IX_TeacherId", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Teams", name: "TeacherId", newName: "ApplicationUserId");
        }
    }
}
