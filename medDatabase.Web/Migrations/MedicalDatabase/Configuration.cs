using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;
using medDatabase.Domain;
using medDatabase.Domain.Interfaces;
using medDatabase.Web.Contexts.AttributeResolution;

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
            var employees = _populater.GetAllEmployees().ToList();
            PopulateTable(context.Employees, employees);

            var rooms = _populater.GetAllRooms().ToList();
            PopulateTable(context.Rooms, rooms);

            var patients = _populater.GetAllPatients().ToList();
            patients.ForEach(p => AttributeResolver.ResolveRoom(p, rooms));
            PopulateTable(context.Patients, patients);

            var doctorSpecialties = _populater.GetAllDoctorSpecialties().ToList();
            PopulateTable(context.DoctorSpecialties, doctorSpecialties);

            var doctors = _populater.GetAllDoctors().ToList();
            doctors.ForEach(d => AttributeResolver.ResolveEmployee(d, employees));
            doctors.ForEach(d => AttributeResolver.ResolveDoctorSpecialty(d, doctorSpecialties));
            PopulateTable(context.Doctors, doctors);

            var nurseSpecialties = _populater.GetAllNurseSpecialties().ToList();
            PopulateTable(context.NurseSpecialties, nurseSpecialties);

            var nurses = _populater.GetAllNurses().ToList();
            nurses.ForEach(n => AttributeResolver.ResolveEmployee(n, employees));
            nurses.ForEach(n => AttributeResolver.ResolveNurseSpecialty(n, nurseSpecialties));
            PopulateTable(context.Nurses, nurses);

            var illnesses = _populater.GetAllIllnesses().ToList();
            PopulateTable(context.Illnesses, illnesses);

            var medications = _populater.GetAllMedications().ToList();
            PopulateTable(context.Medications, medications);

            var addresses = _populater.GetAllAddresses().ToList();
            addresses.ForEach(a => AttributeResolver.ResolvePatient(a, patients));
            PopulateTable(context.Addresses, addresses);

            var appointments = _populater.GetAllAppointments().ToList();
            appointments.ForEach(ap => AttributeResolver.ResolvePatient(ap, patients));
            appointments.ForEach(ap => AttributeResolver.ResolveEmployee(ap, employees));
            PopulateTable(context.Appointments, appointments);

            var medicalHistories = _populater.GetAllMedicalHistories().ToList();
            medicalHistories.ForEach(mh => AttributeResolver.ResolvePatient(mh, patients));
            medicalHistories.ForEach(mh => AttributeResolver.ResolveIllness(mh, illnesses));
            PopulateTable(context.MedicalHistories, medicalHistories);

            var prescriptions = _populater.GetAllPrescriptions().ToList();
            prescriptions.ForEach(pr => AttributeResolver.ResolveEmployee(pr, employees));
            prescriptions.ForEach(pr => AttributeResolver.ResolveMedication(pr, medications));
            prescriptions.ForEach(pr => AttributeResolver.ResolvePatient(pr, patients));
            PopulateTable(context.Prescriptions, prescriptions);

            context.SaveChanges();
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
