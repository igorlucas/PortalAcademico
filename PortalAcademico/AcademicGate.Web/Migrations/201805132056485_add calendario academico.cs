namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcalendarioacademico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicCalendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BegingSemestre = c.DateTime(nullable: false),
                        ProofPeriod = c.String(),
                        LimitThrowProof = c.DateTime(nullable: false),
                        Vacation = c.DateTime(nullable: false),
                        MatriculePeriod = c.DateTime(nullable: false),
                        ReleaseReportCard = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AcademicCalendars");
        }
    }
}
