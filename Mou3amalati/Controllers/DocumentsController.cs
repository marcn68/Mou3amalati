using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public IActionResult PersonalStatusRecord(Citizen c)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            c = _context.Citizens.Find(userName); 

            return View(c);
        }

        public IActionResult Assigned()
        {
            return View();
        }
    }
}
