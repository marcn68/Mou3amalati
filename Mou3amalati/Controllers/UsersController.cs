using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Models;
using Mou3amalati.ViewModels;

namespace Mou3amalati.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UsersController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        // GET: Users
        public IActionResult Index()
        {
            List<ApplicationIdentityUser> users = _userRepository.getAllUsers().ToList();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(string Id)
        {
            if (Id == "")
            {
                return NotFound();
            }

            var user = await _userRepository.getUserById(Id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsersCreateViewModel usersCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.addUser(usersCreateViewModel.User, usersCreateViewModel.Password);
                return RedirectToAction(nameof(Index));
            }
            return View(usersCreateViewModel);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(string Id)
        {
            if (Id == "")
            {
                return NotFound();
            }

            var user = await _userRepository.getUserById(Id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ApplicationIdentityUser user)
        {
            if (id !=user.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _userRepository.updateUser(user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == "")
            {
                return NotFound();
            }

            var user = await _userRepository.getUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userRepository.getUserById(id);
            await _userRepository.deleteUser(user);
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _userRepository.getUserById(id) != null;
        }

        public async Task<IActionResult> ManageUserRoles(string userId)
        {
            ViewBag.userId = userId;
            var user = await _userRepository.getUserById(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return NotFound();
            }
            var model = new List<UserRolesViewModel>();

            foreach (var role in _roleRepository.getAllRoles())
            {
                var userRolesViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await _userRepository.checkUserInRole(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string userId)
        {
            var user = await _userRepository.getUserById(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return NotFound();
            }

            var result = await _userRepository.removeUserRoles(user);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userRepository.assignRolesToUser(user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("Edit", new { Id = userId });
        }
    }
}
