using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Address
    {
        public int Id { get; set; }
        //Mouhafza
        public string State { get; set; }
        //Kada2
        public string District { get; set; }
        public string City { get; set; }
        public string StreetName { get; set; }
        public string BuildingName { get; set; }
        public int Floor { get; set; }
        public string Details { get; set; }
        public virtual ICollection<Citizen> OriginAddressCitizens { get; set; } = new Collection<Citizen>();
        public virtual ICollection<Citizen> ResidenceAddressCitizens { get; set; } = new Collection<Citizen>();
    }
}
