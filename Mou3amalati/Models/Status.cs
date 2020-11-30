using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Status
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
    }
}
