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
        [Key]
        public int id { get; set; }

        [ForeignKey("DocumentRequest")]
        public int documentRequestId { get; set; }
        public virtual DocumentRequest docRequest { get; set; }

        [ForeignKey("Status")]
        public int statusId { get; set; }
        public virtual Status status { get; set; }

        [ForeignKey("Citizen")]
        public int assignedToId { get; set; }
        public virtual Citizen assignedToUser { get; set; }

        public DateTime statusDate { get; set; }
    }
}
