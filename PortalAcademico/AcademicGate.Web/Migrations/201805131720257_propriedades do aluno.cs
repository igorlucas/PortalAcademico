namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propriedadesdoaluno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "RA", c => c.String(maxLength: 80));
            AddColumn("dbo.AspNetUsers", "MotherName", c => c.String());
            AddColumn("dbo.AspNetUsers", "IngressedYear", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "IngressedSerie", c => c.String());
            AddColumn("dbo.AspNetUsers", "CurrentySerie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CurrentySerie");
            DropColumn("dbo.AspNetUsers", "IngressedSerie");
            DropColumn("dbo.AspNetUsers", "IngressedYear");
            DropColumn("dbo.AspNetUsers", "MotherName");
            DropColumn("dbo.AspNetUsers", "RA");
        }
    }
}
