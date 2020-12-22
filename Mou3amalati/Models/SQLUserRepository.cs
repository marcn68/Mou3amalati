using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mou3amalati.Models
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationIdentityUser> userManager;

        public SQLUserRepository(UserManager<ApplicationIdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<ApplicationIdentityUser> addUser(ApplicationIdentityUser user, string pass)
        {
            await userManager.CreateAsync(user, pass);
            return user;
        }

        public async Task<ApplicationIdentityUser> assignUserToCitizen(ApplicationIdentityUser user, string citizenId)
        {
            user.CitizenId = citizenId;
            await updateUser(user);
            return user;
        }

        public async Task<IdentityResult> assignRolesToUser(ApplicationIdentityUser user, IEnumerable<string> Roles)
        {
            var result = await userManager.AddToRolesAsync(user, Roles);
            return result;
        }

        public async Task<bool> checkUserInRole(ApplicationIdentityUser user , string RoleName)
        {
            return await userManager.IsInRoleAsync(user, RoleName);
        }

        public async Task<ApplicationIdentityUser> deleteUser(ApplicationIdentityUser user)
        {
            await userManager.DeleteAsync(user);
            return user;
        }

        public IEnumerable<ApplicationIdentityUser> getAllUsers()
        {
            return userManager.Users;
        }


        public async Task<IList<string>> getRolesByUserId(ApplicationIdentityUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            return roles;
        }


        public ApplicationIdentityUser getUserByCitizenId(string CitizenId)
        {
            var user = userManager.Users.FirstOrDefault(u => u.CitizenId == CitizenId);
            return user;
        }

        public async Task<ApplicationIdentityUser> getUserByEmail(string Email)
        {
            var user = await userManager.FindByEmailAsync(Email);
            return user;
        }

        public async Task<ApplicationIdentityUser> getUserById(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);
            return user;
        }

        public async Task<IdentityResult> removeUserRoles(ApplicationIdentityUser user)
        {
            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);
            return result;
        }

        public async Task<ApplicationIdentityUser> updateUser(ApplicationIdentityUser userChanges)
        {
            var user = await userManager.FindByIdAsync(userChanges.Id);
            user.Email = userChanges.Email;
            user.UserName = userChanges.UserName;
            user.EmailConfirmed = userChanges.EmailConfirmed;
            user.SecurityStamp = userChanges.SecurityStamp;
            user.CitizenId = userChanges.CitizenId;
            user.PhoneNumber = userChanges.PhoneNumber;
            await userManager.UpdateAsync(user);
            return user;
        }
    }
}
