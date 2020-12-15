using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class WorkFlow
    {
        public int Id { get; set; }
        public int OrdinalPosition { get; set; }
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }
        public string RoleId { get; set; }
        public virtual ApplicationIdentityRole Role { get; set; }
    }
}
