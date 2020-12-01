using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        //Mouhafza
        public string State { get; set; }
        //Kada2
        public string District { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public string Details { get; set; }
    }
}
