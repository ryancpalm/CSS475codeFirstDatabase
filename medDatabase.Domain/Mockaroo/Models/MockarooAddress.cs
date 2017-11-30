using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using medDatabase.Domain.Interfaces;
using medDatabase.Domain.Models;

namespace medDatabase.Domain.Mockaroo.Models
{
    public class MockarooAddress : IMockarooConvertible<Address>
    {
        public int PatientId { get; set; }

        public int HouseNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public Address Convert()
        {
            var address = new Address
            {
                PatientId = PatientId,
                Patient = new Patient { Id = PatientId },
                StreetName = Street,
                HouseNumber = HouseNumber,
                City = City,
                State = State,
                ZipCode = ZipCode,
                Country = Country
            };
            return address;
        }
    }
}
