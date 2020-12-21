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
using Mou3amalati.ViewModel;

namespace Mou3amalati.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        HomeRequestAccountViewModel homeRequestAccountViewModel = new HomeRequestAccountViewModel();

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<ApplicationIdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
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

        public IActionResult RequestAccount()
        {
            return View(homeRequestAccountViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RequestAccount(IFormCollection RequestAccount)
        {
            HomeManager home = new HomeManager();
            string id = RequestAccount["identity"];
            string email = RequestAccount["email"];
            string password = home.CreateRandomPassword(10);
            string error = null;

            homeRequestAccountViewModel.id = id;
            homeRequestAccountViewModel.email = email;
            homeRequestAccountViewModel.error = error;
            

            var citizen = await _context.Citizens.FindAsync(id);
            //var citizen = _context.Citizens.Find(id);

            if(citizen != null)
            {
                if (citizen.ApplicationIdentityUserId == null)
                {
                    var user = new ApplicationIdentityUser { UserName = id, Email = email, CitizenId =id};
                    var result = await _userManager.CreateAsync(user, password);
                    user.EmailConfirmed = true;
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");
                        citizen.ApplicationIdentityUser = user;
                        _context.Citizens.Update(citizen);
                        await _context.SaveChangesAsync();
                    }
                    home.EmailSender(id, email, password);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Error Message
                    error = "This account is already requested.";
                    homeRequestAccountViewModel.error = error;
                }
            }
            else
            {
                //Erro Message
                error = "No citizen with this Id was found.";
                homeRequestAccountViewModel.error = error;
            }
            return View(homeRequestAccountViewModel);
        }
    }
}
