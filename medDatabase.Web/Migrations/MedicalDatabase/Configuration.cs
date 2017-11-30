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
            PatientAttributeResolver.ResolveRooms(patients, rooms);
            PopulateTable(context.Patients, patients);

            var doctorSpecialties = _populater.GetAllDoctorSpecialties().ToList();
            PopulateTable(context.DoctorSpecialties, doctorSpecialties);

            var doctors = _populater.GetAllDoctors().ToList();
            DoctorAttributeResolver.ResolveDoctorEmployees(doctors, employees);
            DoctorAttributeResolver.ResolveDoctorSpecialties(doctors, doctorSpecialties);
            PopulateTable(context.Doctors, doctors);

            var nurseSpecialties = _populater.GetAllNurseSpecialties().ToList();
            PopulateTable(context.NurseSpecialties, nurseSpecialties);

            var nurses = _populater.GetAllNurses().ToList();
            NurseAttributeResolver.ResolveEmployees(nurses, employees);
            NurseAttributeResolver.ResolveNurseSpecialties(nurses, nurseSpecialties);
            PopulateTable(context.Nurses, nurses);

            var illnesses = _populater.GetAllIllnesses().ToList();
            PopulateTable(context.Illnesses, illnesses);

            var medications = _populater.GetAllMedications().ToList();
            PopulateTable(context.Medications, medications);

            var addresses = _populater.GetAllAddresses().ToList();
            AddressAttributeResolver.ResolvePatients(addresses, patients);
            PopulateTable(context.Addresses, addresses);

            var appointments = _populater.GetAllAppointments().ToList();
            AppointmentAttributeResolver.ResolvePatients(appointments, patients);
            AppointmentAttributeResolver.ResolveDoctors(appointments, doctors);
            PopulateTable(context.Appointments, appointments);

            var medicalHistories = _populater.GetAllMedicalHistories().ToList();
            MedicalHistoryAttributeResolver.ResolvePatients(medicalHistories, patients);
            MedicalHistoryAttributeResolver.ResolveIllnesses(medicalHistories, illnesses);
            PopulateTable(context.MedicalHistories, medicalHistories);

            var prescriptions = _populater.GetAllPrescriptions().ToList();
            PrescriptionAttributeResolver.ResolveDoctors(prescriptions, doctors);
            PrescriptionAttributeResolver.ResolveMedications(prescriptions, medications);
            PrescriptionAttributeResolver.ResolvePatients(prescriptions, patients);
            PopulateTable(context.Prescriptions, prescriptions);

            SaveChanges(context);
        }


        private static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                ReportEntityValidationErrorsToConsole(ex);
            }
        }

        private static void ReportEntityValidationErrorsToConsole(DbEntityValidationException exception)
        {
            var messageBuilder = new StringBuilder();

            foreach (var failure in exception.EntityValidationErrors)
            {
                messageBuilder.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                foreach (var error in failure.ValidationErrors)
                {
                    messageBuilder.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                    messageBuilder.AppendLine();
                }
            }

            throw new DbEntityValidationException(
                "Entity Validation Failed - errors follow:\n" +
                messageBuilder.ToString(), exception
            );
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
