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
        [Key]
        public int id { get; set; }

        [ForeignKey("Citizen")]
        public int citizenId { get; set; }
        public Citizen user { get; set; }

        [ForeignKey("Citizen")]
        public int assignedToId { get; set; }
        public Citizen assignedToUser { get; set; }

        [ForeignKey("Documents")]
        public int documentId { get; set; }
        public virtual Documents docs { get; set; }

        public DateTime requestDate { get; set; }

        public ICollection<DocumentRequestStatus> documentsRequestStatuses{ get; set; }
}
}
