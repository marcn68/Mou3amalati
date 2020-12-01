using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Price { get; set; }
    }
}
