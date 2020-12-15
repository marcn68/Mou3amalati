using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class ApplicationIdentityUser: IdentityUser
    {
        public string CitizenId { get; set; }
        public virtual Citizen Citizen { get; set; }
    }
}
