namespace medDatabase.Web.Migrations.MedicalDatabase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration003 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Ssn", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Ssn", c => c.String(nullable: false, maxLength: 9));
        }
    }
}
