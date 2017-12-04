namespace medDatabase.Web.Migrations.MedicalDatabase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration002 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Street", c => c.String(nullable: false));
            DropColumn("dbo.Addresses", "StreetName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "StreetName", c => c.String(nullable: false));
            DropColumn("dbo.Addresses", "Street");
        }
    }
}
