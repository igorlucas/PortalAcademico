namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addclassedefrequencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Frequences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.String(),
                        TeamId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Presence = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Frequences");
        }
    }
}
