namespace AcademicGate.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parametrosdoprofessor : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cep = c.String(),
                        Venue = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Cpf", c => c.String(maxLength: 15));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Formation", c => c.String(maxLength: 80));
            AddColumn("dbo.AspNetUsers", "Address_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Address_Id");
            AddForeignKey("dbo.AspNetUsers", "Address_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.AspNetUsers", new[] { "Address_Id" });
            DropColumn("dbo.AspNetUsers", "Address_Id");
            DropColumn("dbo.AspNetUsers", "Formation");
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Cpf");
            DropTable("dbo.Addresses");
        }
    }
}
