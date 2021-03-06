using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class BloodType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; } = new Collection<Citizen>();
    }
}
