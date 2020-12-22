using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public interface IUserRepository
    {
        ApplicationIdentityUser getUserByCitizenId(string CitizenId);
        Task<ApplicationIdentityUser> getUserById(string Id);
        Task<ApplicationIdentityUser> getUserByEmail(string Email);
        IEnumerable<ApplicationIdentityUser> getAllUsers();
        Task<ApplicationIdentityUser> deleteUser(ApplicationIdentityUser user);
        Task<ApplicationIdentityUser> addUser(ApplicationIdentityUser user, string pass);
        Task<ApplicationIdentityUser> updateUser(ApplicationIdentityUser userChanges);
        Task<ApplicationIdentityUser> assignUserToCitizen(ApplicationIdentityUser user, string citizenId);
        Task<IdentityResult> assignRolesToUser(ApplicationIdentityUser user, IEnumerable<string> Roles);
        Task<IList<string>> getRolesByUserId(ApplicationIdentityUser user);
        Task<bool> checkUserInRole(ApplicationIdentityUser user, string RoleName);
        Task<IdentityResult> removeUserRoles(ApplicationIdentityUser user);
    }
}
