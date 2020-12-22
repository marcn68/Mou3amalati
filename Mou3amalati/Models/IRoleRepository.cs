using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public interface IRoleRepository
    {
        Task<ApplicationIdentityRole> getRoleByName(string Name);
        Task<ApplicationIdentityRole> getRoleById(string Id);
        IEnumerable<ApplicationIdentityRole> getAllRoles();
        Task<ApplicationIdentityRole> deleteRole(ApplicationIdentityRole role);
        Task<ApplicationIdentityRole> addRole(ApplicationIdentityRole role);
        Task<ApplicationIdentityRole> updateRole(ApplicationIdentityRole roleChanges);
        Task<string> getRoleIdByName(string Name);
    }
}
