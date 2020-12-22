using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;
using Mou3amalati.ViewModels;

namespace Mou3amalati.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDocumentRepository _documentRepository;
        private readonly IRoleRepository _roleRepository;

        public DocumentsController(ApplicationDbContext context, IDocumentRepository documentRepository, IRoleRepository roleRepository)
        {
            _context = context;
            _documentRepository = documentRepository;
            _roleRepository = roleRepository;
        }

        // GET: Documents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Documents.ToListAsync());
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // GET: Documents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Document document)
        {
            if (ModelState.IsValid)
            {
                await _documentRepository.AddDocument(document);
                return RedirectToAction(nameof(Index));
            }
            return View(document);
        }

        // GET: Documents/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var documentsCreateViewModel = new DocumentsEditViewModel() {
                Document = _documentRepository.GetDocument((int)id)
        };
            if (documentsCreateViewModel.Document == null)
            {
                return NotFound();
            }
            documentsCreateViewModel.Roles = new SelectList(_roleRepository.getAllRoles(), "Id", "Name");
            return View(documentsCreateViewModel);
        }

        // POST: Documents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DocumentsEditViewModel documentsCreateViewModel)
        {
            if (id != documentsCreateViewModel.Document.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                   var document =  _documentRepository.Update(documentsCreateViewModel.Document);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentExists(documentsCreateViewModel.Document.Id))
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
            documentsCreateViewModel.Roles = new SelectList(_roleRepository.getAllRoles(), "Id", "Name");
            return View(documentsCreateViewModel);
        }

        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (document == null)
            {
                return NotFound();
            }

            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
