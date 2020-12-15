using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public double Price { get; set; }
        public virtual ICollection<DocumentRequest> DocumentRequests { get; set; } = new Collection<DocumentRequest>();
        public virtual ICollection<WorkFlow> WorkFlows { get; set; } = new Collection<WorkFlow>();

    }
}
