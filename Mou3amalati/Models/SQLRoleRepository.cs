using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class SQLRoleRepository : IRoleRepository
    {
        private readonly RoleManager<ApplicationIdentityRole> roleManager;

        public SQLRoleRepository(RoleManager<ApplicationIdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public async Task<ApplicationIdentityRole> addRole(ApplicationIdentityRole role)
        {
            await roleManager.CreateAsync(role);
            return role;
        }

        public async Task<ApplicationIdentityRole> deleteRole(ApplicationIdentityRole role)
        {
            await roleManager.DeleteAsync(role);
            return role;
        }

        public IEnumerable<ApplicationIdentityRole> getAllRoles()
        {
            return roleManager.Roles;
        }

        public Task<ApplicationIdentityRole> getRoleById(string Id)
        {
            return roleManager.FindByIdAsync(Id);
        }

        public Task<ApplicationIdentityRole> getRoleByName(string Name)
        {
            return roleManager.FindByNameAsync(Name);
        }

        public async Task<ApplicationIdentityRole> updateRole(ApplicationIdentityRole roleChanges)
        {
            var role = await roleManager.FindByIdAsync(roleChanges.Id);
            role.Name = roleChanges.Name;
            await roleManager.UpdateAsync(role);
            return role;
        }
    }
}
