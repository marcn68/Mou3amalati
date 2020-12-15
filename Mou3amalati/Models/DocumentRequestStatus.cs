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
        public DateTimeOffset StatusDate { get; set; }
        public int DocumentRequestId { get; set; }
        public virtual DocumentRequest DocumentRequest { get; set; }
        public int StatusId { get; set; }
        public virtual DocumentStatus Status { get; set; }
        public string CitizenId { get; set; }
        public virtual Citizen AssignedToCitizen { get; set; }

    }
}
