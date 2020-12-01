using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Family
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<FamilyMember> FamilyMembers { get; set; }
    }
}
