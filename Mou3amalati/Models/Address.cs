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
        public int id { get; set; }
        //Mouhafza
        public string state { get; set; }
        //Kada2
        public string district { get; set; }
        public string city { get; set; }
        public string streetName { get; set; }
        public string buildingName { get; set; }
        public string details { get; set; }
    }
}
