﻿using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;
using Mou3amalati.ViewModels;

namespace Mou3amalati.Controllers
{
    public class DocumentRequestController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private string assignedToValue;

        public DocumentRequestController(ApplicationDbContext context, UserManager<ApplicationIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult PersonalStatusRecord()
        {
            CitizensCreateViewModel citizenVM = new CitizensCreateViewModel();
            SQLCitizenRepository citizenRepo = new SQLCitizenRepository(_context);

            var citizenId = User.FindFirstValue(ClaimTypes.Name);

            citizenVM.Citizen = citizenRepo.GetCitizen(citizenId);

            return View(citizenVM);
        }

        public async Task<IActionResult> Assigned()
        {
            DocumentsAssignedViewModel docVM = new DocumentsAssignedViewModel();

            var userName = User.FindFirstValue(ClaimTypes.Name);
            Citizen c = _context.Citizens.Include(citizen => citizen.OriginAddress).FirstOrDefault(c => c.Id == userName);

            var usersOfRole = await _userManager.GetUsersInRoleAsync("Mokhtar");

            foreach(var u in usersOfRole)
            {
                string username = u.UserName;
                var rList = _context.Citizens.Include(citizen => citizen.OriginAddress)
                    .Include(citizen => citizen.ApplicationIdentityUser)
                    .Where(citizen => citizen.OriginAddress.City == c.OriginAddress.City && citizen.ApplicationIdentityUser.UserName == username)
                    .ToList();

                docVM.roleList = new SelectList(
                    rList, "Id", "FullName"
                    );
            }

            return View(docVM);
        }

        //[HttpPost]
        //public IActionResult Assigned(DocumentsAssignedViewModel docVM)
        //{
        //    assignedToValue = Request.Form["roleList"].ToString();

        //    return View(docVM);
        //}

        public IActionResult RequestFinished()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            Citizen c = _context.Citizens.Find(userName);

            DateTime nowDate = DateTime.Now;

            Document doc = _context.Documents.Where(d => d.Name == "Personal Status Record").First();

            var wf = _context.WorkFlows.Where(w => w.DocumentId == doc.Id).ToList();
            WorkFlow workflow = new WorkFlow();

            foreach (var w in wf)
            {
                if (w.OrdinalPosition == 1)
                {
                    ApplicationIdentityRole role = _context.Roles.Find(w.RoleId);
                    workflow = w;
                    break;
                }
            }

            //WorkFlow wf = _context.WorkFlows.Where(w => w.DocumentId == doc.Id && w.RoleId == role.Id).First();

            DocumentRequest docRequest = new DocumentRequest()
            {
                RequestDate = nowDate,
                CurrentOrdinalPositionInWorkflow = workflow.OrdinalPosition,
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
