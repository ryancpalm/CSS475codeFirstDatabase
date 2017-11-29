using System.Collections.Generic;
using medDatabase.Domain;
using medDatabase.Domain.Interfaces;

namespace medDatabase.Web.Migrations.MedicalDatabase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<medDatabase.Web.Contexts.MedicalDatabaseContext>
    {
        private readonly IPopulater _populater;

        public Configuration()
        {
            _populater = new Populater();
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MedicalDatabase";
        }

        protected override void Seed(Contexts.MedicalDatabaseContext context)
        {
            // TODO: Correct populated objects to use the corresponding object in the appropriate collection
            var employees = _populater.GetAllEmployees();
            PopulateTable(context.Employees, employees);
            var patients = _populater.GetAllPatients();
            PopulateTable(context.Patients, patients);
            var doctors = _populater.GetAllDoctors();
            PopulateTable(context.Doctors, doctors);
            var doctorSpecialties = _populater.GetAllDoctorSpecialties();
            PopulateTable(context.DoctorSpecialties, doctorSpecialties);
            var nurses = _populater.GetAllNurses();
            PopulateTable(context.Nurses, nurses);
            var nurseSpecialties = _populater.GetAllNurseSpecialties();
            PopulateTable(context.NurseSpecialties, nurseSpecialties);
            var illnesses = _populater.GetAllIllnesses();
            PopulateTable(context.Illnesses, illnesses);
            var medications = _populater.GetAllMedications();
            PopulateTable(context.Medications, medications);
            var rooms = _populater.GetAllRooms();
            PopulateTable(context.Rooms, rooms);
            var addresses = _populater.GetAllAddresses();
            PopulateTable(context.Addresses, addresses);
            var appointments = _populater.GetAllAppointments();
            PopulateTable(context.Appointments, appointments);
            var medicalHistories = _populater.GetAllMedicalHistories();
            PopulateTable(context.MedicalHistories, medicalHistories);
            var prescriptions = _populater.GetAllPrescriptions();
            PopulateTable(context.Prescriptions, prescriptions);
        }

        private static void PopulateTable<T>(IDbSet<T> table, IEnumerable<T> values) where T : class
        {
            foreach (var value in values)
            {
                table.AddOrUpdate(value);
            }
        }
    }
}
