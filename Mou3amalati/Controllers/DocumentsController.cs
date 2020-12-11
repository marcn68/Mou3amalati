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

        public IActionResult Assigned()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            Citizen c = _context.Citizens.Find(userName);

            SelectList list = new SelectList(_context.Citizens.Where(a => a.OriginAddress.City == c.OriginAddress.City && a.Role.Id == "1")
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
