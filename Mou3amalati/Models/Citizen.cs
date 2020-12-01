using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Citizen : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int FamilyId { get; set; }
        public virtual Family Family { get; set; }

        public virtual FamilyRole FamilyRole { get; set; }

        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }

        public Religion Religion { get; set; }
        public CivilStatus CivilStatus { get; set; }

        public BloodType BloodType { get; set; }
        public Address OriginAddress { get; set; }
        public Address ResidenceAddress { get; set; }

        //Ra2em el Sejel
        public int CivilRegisterNumber { get; set; }
        public Gender Gender { get; set; }

        public IdentityRole Role { get; set; }

        [NotMapped]
        public ICollection<DocumentRequest> DocsRequested { get; set; }
        [NotMapped]
        public ICollection<DocumentRequest> DocsAssigned { get; set; }
        [NotMapped]
        public ICollection<DocumentRequest> DocsAssignedStatus { get; set; }
    }
}
