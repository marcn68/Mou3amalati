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
using Mou3amalati.ViewModel;

namespace Mou3amalati.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private string assignedToValue;

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
            DocumentsAssignedViewModel docVM = new DocumentsAssignedViewModel();

            var userName = User.FindFirstValue(ClaimTypes.Name);
            Citizen c = _context.Citizens.Find(userName);

            var usersOfRole = await _userManager.GetUsersInRoleAsync("Mokhtar");

            foreach(var u in usersOfRole)
            {
                string username = u.UserName;
                docVM.roleList = new SelectList(
                _context.Citizens.Where(
                citizen => citizen.OriginAddress.City == c.OriginAddress.City && citizen.ApplicationIdentityUser.UserName == username )
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }), "CitizenFName", "CitizenLName");
            }

            return View(docVM);
        }

        [HttpPost]
        public IActionResult Assigned(DocumentsAssignedViewModel docVM)
        {
            assignedToValue = Request.Form["roleList"].ToString();

            return View(docVM);
        }

        public IActionResult RequestFinished()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            Citizen c = _context.Citizens.Find(userName);

            DateTime nowDate = DateTime.Now;

            Document doc = (Document)_context.Documents.Where(d => d.Name == "Personal Status Record");

            ApplicationIdentityRole role = (ApplicationIdentityRole) _context.Roles.Where(d => d.Name == "Mokhtar");

            WorkFlow wf = _context.WorkFlows.Where(w => w.DocumentId == doc.Id && w.RoleId == role.Id).First();

            DocumentRequest docRequest = new DocumentRequest()
            {
                RequestDate = nowDate,
                CurrentOrdinalPositionInWorkflow = wf.OrdinalPosition,
                RequestedByCitizenId = c.Id,
                CurrentAssignedToCitizenId = assignedToValue,
                DocumentId = doc.Id
            };

            _context.DocumentRequests.Add(docRequest);

            int docRequestId = _context.DocumentRequests.Where(d => d == docRequest).Select(c => c.Id).FirstOrDefault();

            DocumentStatus docStatus = _context.DocumentStatuses.Find(1);
            DocumentRequestStatus docRequestStatus = new DocumentRequestStatus()
            {
                StatusDate = nowDate,
                DocumentRequestId = docRequestId,
                StatusId = docStatus.Id,
                CitizenId = assignedToValue
            };

            _context.DocumentRequestStatuses.Add(docRequestStatus);

            _context.SaveChanges();
            
            return View();
        }
    }
}
