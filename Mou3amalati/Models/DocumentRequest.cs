using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class DocumentRequest
    {
        public int Id { get; set; }
        public DateTimeOffset RequestDate { get; set; }
        public int CurrentOrdinalPositionInWorkflow { get; set; }
        public string RequestedByCitizenId { get; set; }
        public virtual Citizen RequestedByCitizen { get; set; }
        public string CurrentAssignedToCitizenId { get; set; }
        public virtual Citizen CurrentAssignedToCitizen { get; set; }
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public virtual ICollection<DocumentRequestStatus> DocumentsRequestStatuses { get; set; } = new Collection<DocumentRequestStatus>();
}
}
