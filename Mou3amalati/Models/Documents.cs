﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Documents
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string details { get; set; }
        public string price { get; set; }
    }
}