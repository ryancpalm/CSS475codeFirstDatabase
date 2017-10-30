using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace medDatabase
{

    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new MedDatabaseContext())
            {
                // Add data here.
            }
        }
    }

    [Table("Employee")]
    public class Employee
    {
        

        // Key (Must be named ID)?
        public int id { get; set; }

        // No '-'
        [StringLength(9)]
        public string SSN { get; set; }

        // Will continue adding attributes later...

    }

    // Used as the context for communication with our database.
    public class MedDatabaseContext : DbContext
    {
        public MedDatabaseContext() : base ("name=MedDatabaseContext")
        {

        }

        public virtual DbSet<Employee> Employee { get; set; }
    }
}
