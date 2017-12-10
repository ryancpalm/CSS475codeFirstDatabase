using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using medDatabase.Domain;
using medDatabase.Domain.Interfaces;
using medDatabase.Web.Contexts;

namespace medDatabase.Web.Migrations.MedicalDatabase
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<medDatabase.Web.Contexts.MedicalDatabaseContext>
    {
        [DllImport("kernel32")]
        private static extern bool AllocConsole();
        private readonly IPopulater _populater;

        public Configuration()
        {
            _populater = new Populater();
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MedicalDatabase";
        }

        protected override void Seed(Contexts.MedicalDatabaseContext context)
        {
            AllocConsole();
            Console.WriteLine("Populating employees.");
            var employees = _populater.GetAllEmployees().ToList();
            AttributeResolver.ResolveSSNs(employees);
            PopulateTable(context.Employees, employees);

            Console.WriteLine("Populating rooms.");
            var rooms = _populater.GetAllRooms().ToList();
            PopulateTable(context.Rooms, rooms);

            Console.WriteLine("Populating patients.");
            var patients = _populater.GetAllPatients().ToList();
            AttributeResolver.ResolveSSNs(patients);
            patients.ForEach(p => AttributeResolver.ResolveRoom(p, rooms));
            PopulateTable(context.Patients, patients);

            Console.WriteLine("Populating doctor specialties.");
            var doctorSpecialties = _populater.GetAllDoctorSpecialties().ToList();
            PopulateTable(context.DoctorSpecialties, doctorSpecialties);

            Console.WriteLine("Populating doctors.");
            var doctors = _populater.GetAllDoctors().ToList();
            doctors.ForEach(d => AttributeResolver.ResolveEmployee(d, employees));
            doctors.ForEach(d => AttributeResolver.ResolveDoctorSpecialty(d, doctorSpecialties));
            PopulateTable(context.Doctors, doctors);

            Console.WriteLine("Populating nurse specialties.");
            var nurseSpecialties = _populater.GetAllNurseSpecialties().ToList();
            PopulateTable(context.NurseSpecialties, nurseSpecialties);

            Console.WriteLine("Populating nurses.");
            var nurses = _populater.GetAllNurses().ToList();
            nurses.ForEach(n => AttributeResolver.ResolveEmployee(n, employees));
            nurses.ForEach(n => AttributeResolver.ResolveNurseSpecialty(n, nurseSpecialties));
            PopulateTable(context.Nurses, nurses);

            Console.WriteLine("Populating illnesses.");
            var illnesses = _populater.GetAllIllnesses().ToList();
            PopulateTable(context.Illnesses, illnesses);

            Console.WriteLine("Populating medications.");
            var medications = _populater.GetAllMedications().ToList();
            PopulateTable(context.Medications, medications);

            Console.WriteLine("Populating addresses.");
            var addresses = _populater.GetAllAddresses().ToList();
            addresses.ForEach(a => AttributeResolver.ResolvePatient(a, patients));
            PopulateTable(context.Addresses, addresses);

            Console.WriteLine("Populating appointments.");
            var appointments = _populater.GetAllAppointments().ToList();
            appointments.ForEach(ap => AttributeResolver.ResolvePatient(ap, patients));
            appointments.ForEach(ap => AttributeResolver.ResolveEmployee(ap, employees));
            PopulateTable(context.Appointments, appointments);

            Console.WriteLine("Populating medical histories.");
            var medicalHistories = _populater.GetAllMedicalHistories().ToList();
            medicalHistories.ForEach(mh => AttributeResolver.ResolvePatient(mh, patients));
            medicalHistories.ForEach(mh => AttributeResolver.ResolveIllness(mh, illnesses));
            PopulateTable(context.MedicalHistories, medicalHistories);

            Console.WriteLine("Populating prescriptions.");
            var prescriptions = _populater.GetAllPrescriptions().ToList();
            prescriptions.ForEach(pr => AttributeResolver.ResolveEmployee(pr, employees));
            prescriptions.ForEach(pr => AttributeResolver.ResolveMedication(pr, medications));
            prescriptions.ForEach(pr => AttributeResolver.ResolvePatient(pr, patients));
            PopulateTable(context.Prescriptions, prescriptions);

            context.SaveChanges();
        }

        private static void PopulateTable<T>(IDbSet<T> table, IEnumerable<T> values) where T : class
        {
            values = values.ToList();
            var counter = 1;
            var total = values.Count();
            foreach (var value in values)
            {
                Console.WriteLine($"\t{counter}\t/\t{total}");
                counter++;
                table.AddOrUpdate(value);
            }
        }
    }
}
