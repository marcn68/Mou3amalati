using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mou3amalati.Data;
using Mou3amalati.Models;

namespace Mou3amalati.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DocumentsController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult PersonalStatusRecord()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            Citizen c = _context.Citizens.Find(userName); 

            return View(c);
        }

        public async Task<IActionResult> Assigned()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            Citizen c = _context.Citizens.Find(userName);

            var usersOfRole = await _userManager.GetUsersInRoleAsync("Mokhtar");

            //var mokhtar_role = _context.UserRoles.Where(a => a.RoleId == "1");

            SelectList list = new SelectList(
                _context.Citizens.Where(
                citizen => citizen.OriginAddress.City == c.OriginAddress.City && citizen == usersOfRole)
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }), "CitizenFName", "CitizenLName");
            return View();
        }

        public IActionResult RequestFinished()
        {
            return View();
        }
    }
}
