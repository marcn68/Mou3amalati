using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class DocumentRequest
    {
        public int Id { get; set; }
        public Citizen User { get; set; }
        public Citizen AssignedToUser { get; set; }

        public Document Document { get; set; }

        public DateTime RequestDate { get; set; }

        public ICollection<DocumentRequestStatus> DocumentsRequestStatuses{ get; set; }
}
}
