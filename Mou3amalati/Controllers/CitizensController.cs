using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;
using Mou3amalati.ViewModels;

namespace Mou3amalati.Controllers
{
    public class CitizensController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ICitizenRepository _citizenRepository;

        public CitizensController(ApplicationDbContext context, ICitizenRepository citizenRepository)
        {
            _context = context;
            _citizenRepository = citizenRepository;
        }

        // GET: Citizens
        public IActionResult Index()
        {
            List<Citizen> citizens = _citizenRepository.GetAllCitizens().ToList();
            return View(citizens);
        }

        // GET: Citizens/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = _citizenRepository.GetCitizen(id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // GET: Citizens/Create
        public IActionResult Create()
        {
            CitizensCreateViewModel citizensCreateViewModel = new CitizensCreateViewModel
            {
                BloodTypes = new SelectList(_context.BloodTypes, "Id", "Type"),
                CivilStatuses = new SelectList(_context.CivilStatuses, "Id", "Description"),
                Genders = new SelectList(_context.Genders, "Id", "Description"),
                Religions = new SelectList(_context.Religions, "Id", "Description"),
                LifeStatuses = new SelectList(_context.LifeStatuses, "Id", "Status")
            };
            return View(citizensCreateViewModel);
        }

        // POST: Citizens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CitizensCreateViewModel citizensCreateViewModel)
        {
            if (ModelState.IsValid)
            {
                var citizen = _citizenRepository.AddCitizen(citizensCreateViewModel.Citizen);
                return RedirectToAction(nameof(Index));
            }
            citizensCreateViewModel.BloodTypes = new SelectList(_context.BloodTypes, "Id", "Type");
            citizensCreateViewModel.CivilStatuses = new SelectList(_context.CivilStatuses, "Id", "Description");
            citizensCreateViewModel.Genders = new SelectList(_context.Genders, "Id", "Description");
            citizensCreateViewModel.Religions = new SelectList(_context.Religions, "Id", "Description");
            citizensCreateViewModel.LifeStatuses = new SelectList(_context.LifeStatuses, "Id", "Status");
            return View(citizensCreateViewModel);
        }

        // GET: Citizens/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var citizensCreateViewModel = new CitizensCreateViewModel();
            citizensCreateViewModel.Citizen = _citizenRepository.GetCitizen(id);

            if (citizensCreateViewModel.Citizen == null)
            {
                return NotFound();
            }
            citizensCreateViewModel.BloodTypes = new SelectList(_context.BloodTypes, "Id", "Type", citizensCreateViewModel.Citizen.BloodTypeId);
            citizensCreateViewModel.CivilStatuses = new SelectList(_context.CivilStatuses, "Id", "Description", citizensCreateViewModel.Citizen.CivilStatusId);
            citizensCreateViewModel.Genders = new SelectList(_context.Genders, "Id", "Description", citizensCreateViewModel.Citizen.GenderId);
            citizensCreateViewModel.Religions = new SelectList(_context.Religions, "Id", "Description", citizensCreateViewModel.Citizen.ReligionId);
            citizensCreateViewModel.LifeStatuses = new SelectList(_context.LifeStatuses, "Id", "Status", citizensCreateViewModel.Citizen.LifeStatusId);
            return View(citizensCreateViewModel);
        }

        // POST: Citizens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, CitizensCreateViewModel citizensCreateViewModel)
        {
            var citizen = citizensCreateViewModel.Citizen;
            if (id != citizen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _citizenRepository.Update(citizen);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenExists(citizen.Id))
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
            citizensCreateViewModel.BloodTypes = new SelectList(_context.BloodTypes, "Id", "Type", citizensCreateViewModel.Citizen.BloodTypeId);
            citizensCreateViewModel.CivilStatuses = new SelectList(_context.CivilStatuses, "Id", "Description", citizensCreateViewModel.Citizen.CivilStatusId);
            citizensCreateViewModel.Genders = new SelectList(_context.Genders, "Id", "Description", citizensCreateViewModel.Citizen.GenderId);
            citizensCreateViewModel.Religions = new SelectList(_context.Religions, "Id", "Description", citizensCreateViewModel.Citizen.ReligionId);
            citizensCreateViewModel.LifeStatuses = new SelectList(_context.LifeStatuses, "Id", "Status", citizensCreateViewModel.Citizen.LifeStatusId);
            return View(citizensCreateViewModel);
        }

        // GET: Citizens/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = _citizenRepository.GetCitizen(id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // POST: Citizens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var citizen = _citizenRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CitizenExists(string id)
        {
            return _citizenRepository.GetCitizen(id) != null;
        }
    }
}
