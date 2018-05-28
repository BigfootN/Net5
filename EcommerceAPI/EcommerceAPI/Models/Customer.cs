using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
    }
}
