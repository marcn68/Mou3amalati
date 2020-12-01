using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class DocumentRequestStatus
    {
        public int Id { get; set; }

        public DocumentRequest DocumentRequest { get; set; }
        public Status Status { get; set; }
        public Citizen AssignedToUser { get; set; }

        public DateTime StatusDate { get; set; }
    }
}
