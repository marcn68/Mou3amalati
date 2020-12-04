using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mou3amalati.Models;
using Mou3amalati.BLL;
using Mou3amalati.Data;
using Microsoft.AspNetCore.Identity;

namespace Mou3amalati.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RequestAccount()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAccountAsync(IFormCollection RequestAccount)
        {
            HomeManager home = new HomeManager();
            string id = RequestAccount["identity"];
            string email = RequestAccount["email"];
            string password = home.CreateRandomPassword(10);

            var citizen = await _context.Citizens.FindAsync(id);
            //var citizen = _context.Citizens.Find(id);

            if(citizen != null)
            {
                if (citizen.IdentityUser.Id != null)
                {
                    var user = new IdentityUser { UserName = citizen.IdentityUser.Email, Email = citizen.IdentityUser.Email };
                    var result = await _userManager.CreateAsync(user, citizen.IdentityUser.PasswordHash);
                    user.EmailConfirmed = true;
                    citizen.IdentityUser = null;
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        citizen.IdentityUser = user;
                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();
                    }
                    home.EmailSender(id, email, password);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
