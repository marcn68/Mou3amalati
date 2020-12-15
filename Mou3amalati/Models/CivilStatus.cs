using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class CivilStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Citizen> Citizens { get; set; } = new Collection<Citizen>();
    }
}
