using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Mou3amalati.Controllers
{
    public class CitizenUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitizenUserController(ApplicationDbContext context)
        {
            _context = context;
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

            List<DocumentRequestStatus> citizenUserDocuments = _context.DocumentRequestStatuses
                .Include(c => c.DocumentRequest)
                .Include(c => c.DocumentRequest.Document)
                //.Include(c => c.DocumentRequest.Document.WorkFlows)
                .Include(c => c.DocumentRequest.Document.WorkFlows).ThenInclude(i => i.Role)
                .Include(c => c.DocumentRequest.RequestedByCitizen)
                .Include(c => c.AssignedToCitizen)
                .Include(c => c.Status)
                .Where(d => d.DocumentRequest.RequestedByCitizenId == userName)
                .ToList();

            return View(citizenUserDocuments);
        }
    }
}
