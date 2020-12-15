using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Citizen
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherFirstName { get; set; }
        public string MotherFirstName { get; set; }
        public string MotherMaidenName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string BirthPlace { get; set; }
        //Ra2em el Sejel
        public int CivilRegisterNumber { get; set; }
        public bool Deleted { get; set; }
        public int ReligionId { get; set; }
        public virtual Religion Religion { get; set; }
        public int CivilStatusId { get; set; }
        public virtual CivilStatus CivilStatus { get; set; }
        public int BloodTypeId { get; set; }
        public virtual BloodType BloodType { get; set; }
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }
        public int LifeStatusId { get; set; }
        public virtual LifeStatus LifeStatus { get; set; }
        public int OriginAddressId { get; set; }
        public virtual Address OriginAddress { get; set; }
        public int ResidenceAddressId { get; set; }
        public virtual Address ResidenceAddress { get; set; }
        public string ApplicationIdentityUserId { get; set; }
        public virtual ApplicationIdentityUser ApplicationIdentityUser { get; set; }
        public virtual ICollection<DocumentRequest> DocsRequested { get; set; } = new Collection<DocumentRequest>();
        public virtual ICollection<DocumentRequest> DocsAssigned { get; set; } = new Collection<DocumentRequest>();
        public virtual ICollection<DocumentRequestStatus> DocsAssignedStatus { get; set; } = new Collection<DocumentRequestStatus>();
    }
}
