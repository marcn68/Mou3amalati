using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class ApplicationIdentityRole: IdentityRole
    {
        public virtual ICollection<WorkFlow> WorkFlows { get; set; } = new Collection<WorkFlow>();
    }
}
