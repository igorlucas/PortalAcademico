namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atualizandoclasseteam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Name");
        }
    }
}
