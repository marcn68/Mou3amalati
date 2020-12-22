using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;
using Mou3amalati.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mou3amalati.Controllers
{
    public class CitizenUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationIdentityUser> _userManager;

        public CitizenUserController(ApplicationDbContext context, UserManager<ApplicationIdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocumentsList()
        {
            return View();
        }

        public IActionResult UserDocumentList()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);

            DocumentRequest docsRequested = new DocumentRequest();

            //List<DocumentRequest> citizenUserDocuments = _context.DocumentRequests
            //    .Include(c => c.DocumentsRequestStatuses)
            //    .Where(d => d.RequestedByCitizenId == userName)
            //    .ToList();

            List<DocumentRequestStatus> citizenUserDocuments = _context.DocumentRequestStatuses
                .Include(c => c.DocumentRequest)
                .Include(c => c.DocumentRequest.Document)
                .Include(c => c.DocumentRequest.RequestedByCitizen)
                .Include(c => c.AssignedToCitizen)
                .Include(c => c.Status)
                .Where(d => d.DocumentRequest.RequestedByCitizenId == userName)
                .ToList();

            return View(citizenUserDocuments);
        }


        public IActionResult WorkDocumentList()
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);


            //List<DocumentRequest> citizenUserDocuments = _context.DocumentRequests
            //    .Include(c => c.DocumentsRequestStatuses)
            //    .Where(d => d.RequestedByCitizenId == userName)
            //    .ToList();

            var workDocuments = _context.DocumentRequests
                .Include(c => c.Document)
                .Where(d => d.CurrentAssignedToCitizenId == userName)
                .ToList();

            return View(workDocuments);
        }

        public async Task<IActionResult> SendtoNext(int DocRequestId)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            Citizen c = _context.Citizens.Include(citizen => citizen.OriginAddress).FirstOrDefault(c => c.Id == userName);
            // get next ordinal position (curr + 1)
            // get next role index workflow index (curr - 1)
            // populate selectlist
            // create new document request status
            // add the document request to the new role
            // update currordinalposition
            // remove doc request from curr role citizen
            var docAssignedViewModel = new DocumentsAssignedViewModel();
            var docRequest = _context.DocumentRequests.Find(DocRequestId);
            var nextOrdinalPosition = docRequest.CurrentOrdinalPositionInWorkflow + 1;
            var nextRoleIndex = docRequest.CurrentOrdinalPositionInWorkflow;
            var roleName = docRequest.Document.WorkFlows[nextRoleIndex].Role.Name;
            docAssignedViewModel.RoleName = roleName;
            if(roleName == "Citizen"){
                docAssignedViewModel.isLast = true;
            }
            var usersOfRole = await _userManager.GetUsersInRoleAsync(roleName);
            foreach (var u in usersOfRole)
            {
                var rList = _context.Citizens.Include(citizen => citizen.OriginAddress)
                    .Include(citizen => citizen.ApplicationIdentityUser)
                    .Where(citizen => citizen.OriginAddress.City == c.OriginAddress.City && citizen.ApplicationIdentityUser.UserName == u.UserName)
                    .ToList();

                docAssignedViewModel.roleList = new SelectList(
                    rList, "Id", "FullName"
                    );
            }

            return View(docAssignedViewModel);
        }

        [HttpPost]
        public IActionResult SendtoNext(DocumentsAssignedViewModel docAssignedViewModel)
        {
            DocumentRequestStatus docRequestStatus = new DocumentRequestStatus()
            {
                StatusDate = DateTime.Now,
                DocumentRequestId = docAssignedViewModel.DocRequestId,
                CitizenId = docAssignedViewModel.SelectedRoleCitizenId
            };
            int StatusId;
            if(docAssignedViewModel.isLast == true)
            {
                StatusId = _context.DocumentStatuses.FirstOrDefault(x => x.Description == "Done").Id;
            } else
            {
                StatusId = _context.DocumentStatuses.FirstOrDefault(x => x.Description == "In Progress").Id;
            }
            docRequestStatus.StatusId = StatusId;

            var nextAssignedToCititzen = _context.Citizens.Find(docAssignedViewModel.SelectedRoleCitizenId);
            var docRequest = _context.DocumentRequests.Find(docAssignedViewModel.DocRequestId);
            docRequest.CurrentOrdinalPositionInWorkflow++;
            docRequest.CurrentAssignedToCitizenId = docAssignedViewModel.SelectedRoleCitizenId;
            docRequest.DocumentsRequestStatuses.Add(docRequestStatus);
            nextAssignedToCititzen.DocsAssigned.Add(docRequest);
            nextAssignedToCititzen.DocsAssignedStatus.Add(docRequestStatus);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var previousAssignedToCitizen = _context.Citizens.FirstOrDefault(c => c.Id == userName);
            var docRequest1 = _context.DocumentRequests.Find(docAssignedViewModel.DocRequestId);
            previousAssignedToCitizen.DocsAssigned.Remove(docRequest1);
            _context.SaveChanges();
            

            return View(docAssignedViewModel);
        }

    }

}
