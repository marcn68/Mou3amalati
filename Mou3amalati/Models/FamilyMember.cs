using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class FamilyMember
    {
        public int Id { get; set; }
        public Citizen Citizen { get; set; }
        public Family Family { get; set; }
        public FamilyRole FamilyRole { get; set; }
    }
}
