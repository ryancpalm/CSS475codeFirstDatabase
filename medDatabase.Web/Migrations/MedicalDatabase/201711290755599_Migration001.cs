namespace medDatabase.Web.Migrations.MedicalDatabase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        HouseNumber = c.Int(nullable: false),
                        StreetName = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Patient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.Patients", t => t.Patient_Id, cascadeDelete: true)
                .Index(t => t.Patient_Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ssn = c.String(nullable: false, maxLength: 9),
                        RoomId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        AdmissionDate = c.DateTime(nullable: false),
                        DischargeDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        DateAndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DoctorId })
                .ForeignKey("dbo.Employees", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ssn = c.String(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        OnSite = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        DoctorSpecialtyId = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.DoctorSpecialties", t => t.DoctorSpecialtyId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.DoctorSpecialtyId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.DoctorSpecialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Illnesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedicalHistories",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        IllnessId = c.Int(nullable: false),
                        DiagnosisDate = c.DateTime(nullable: false),
                        LastVisitDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.IllnessId })
                .ForeignKey("dbo.Illnesses", t => t.IllnessId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.IllnessId);
            
            CreateTable(
                "dbo.Medications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DosageMgPerLbBodyWeight = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nurses",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        NurseSpecialtyId = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.NurseSpecialties", t => t.NurseSpecialtyId, cascadeDelete: true)
                .Index(t => t.NurseSpecialtyId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.NurseSpecialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                        MedicationId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Refills = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => new { t.PatientId, t.DoctorId, t.MedicationId })
                .ForeignKey("dbo.Employees", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Medications", t => t.MedicationId, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId)
                .Index(t => t.MedicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prescriptions", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Prescriptions", "MedicationId", "dbo.Medications");
            DropForeignKey("dbo.Prescriptions", "DoctorId", "dbo.Employees");
            DropForeignKey("dbo.Nurses", "NurseSpecialtyId", "dbo.NurseSpecialties");
            DropForeignKey("dbo.Nurses", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.MedicalHistories", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.MedicalHistories", "IllnessId", "dbo.Illnesses");
            DropForeignKey("dbo.Doctors", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Doctors", "DoctorSpecialtyId", "dbo.DoctorSpecialties");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorId", "dbo.Employees");
            DropForeignKey("dbo.Addresses", "Patient_Id", "dbo.Patients");
            DropForeignKey("dbo.Patients", "RoomId", "dbo.Rooms");
            DropIndex("dbo.Prescriptions", new[] { "MedicationId" });
            DropIndex("dbo.Prescriptions", new[] { "DoctorId" });
            DropIndex("dbo.Prescriptions", new[] { "PatientId" });
            DropIndex("dbo.Nurses", new[] { "Employee_Id" });
            DropIndex("dbo.Nurses", new[] { "NurseSpecialtyId" });
            DropIndex("dbo.MedicalHistories", new[] { "IllnessId" });
            DropIndex("dbo.MedicalHistories", new[] { "PatientId" });
            DropIndex("dbo.Doctors", new[] { "Employee_Id" });
            DropIndex("dbo.Doctors", new[] { "DoctorSpecialtyId" });
            DropIndex("dbo.Appointments", new[] { "DoctorId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Patients", new[] { "RoomId" });
            DropIndex("dbo.Addresses", new[] { "Patient_Id" });
            DropTable("dbo.Prescriptions");
            DropTable("dbo.NurseSpecialties");
            DropTable("dbo.Nurses");
            DropTable("dbo.Medications");
            DropTable("dbo.MedicalHistories");
            DropTable("dbo.Illnesses");
            DropTable("dbo.DoctorSpecialties");
            DropTable("dbo.Doctors");
            DropTable("dbo.Employees");
            DropTable("dbo.Appointments");
            DropTable("dbo.Rooms");
            DropTable("dbo.Patients");
            DropTable("dbo.Addresses");
        }
    }
}
