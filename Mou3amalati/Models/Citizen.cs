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
        [Key]
        public string Id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }

        [ForeignKey("Citizen")]
        public int fatherId { get; set; }
        //public virtual Citizen father { get; set; }

        [ForeignKey("Citizen")]
        public int motherId { get; set; }
        //public virtual Citizen mother { get; set; }

        public DateTime birthDate { get; set; }
        public string birthPlace { get; set; }

        [ForeignKey("Religion")]
        public int religionId { get; set; }
        public virtual Religion religion { get; set; }

        [ForeignKey("CivilStatus")]
        public int civilStatusId { get; set; }
        public virtual CivilStatus civilStatus { get; set; }

        [ForeignKey("BloodType")]
        public int bloodTypeId { get; set; }
        public virtual BloodType bloodType { get; set; }

        [ForeignKey("Address")]
        public int originAddressId { get; set; }
        public virtual Address originAddress { get; set; }

        [ForeignKey("Address")]
        public int? residenceAddressId { get; set; }
        public virtual Address residenceAddress { get; set; }

        //Ra2em el Sejel
        public int civilRegisterNumber { get; set; }

        [ForeignKey("Gender")]
        public int genderId { get; set; }
        public virtual Gender gender { get; set; }

        [ForeignKey("IdentityRole")]
        public string roleId { get; set; }
        public virtual IdentityRole role { get; set; }

        [NotMapped]
        public ICollection<DocumentRequest> docsRequested { get; set; }
        [NotMapped]
        public ICollection<DocumentRequest> docsAssigned { get; set; }
        [NotMapped]
        public ICollection<DocumentRequest> docsAssignedStatus { get; set; }
    }
}
