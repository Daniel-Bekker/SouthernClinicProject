using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SouthernClinicProject.Models;

namespace SouthernClinicProject.Controllers
{
    public class PrescriptionsController : Controller
    {
        private readonly ClinicContext _context;

        public PrescriptionsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: Prescriptions
        public async Task<IActionResult> Index()
        {
            var clinicContext = _context.Prescriptions.Include(p => p.Item).Include(p => p.PatientSsnNavigation).Include(p => p.Pharmacy);
            return View(await clinicContext.ToListAsync());
        }

        // GET: Prescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Prescriptions == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.Item)
                .Include(p => p.PatientSsnNavigation)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // GET: Prescriptions/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            ViewData["PatientSsn"] = new SelectList(_context.Patients, "Ssn", "Ssn");
            ViewData["PharmacyId"] = new SelectList(_context.Pharmacies, "PharmacyId", "PharmacyId");
            return View();
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrescriptionId,PatientSsn,PharmacyId,ItemId,Quantity,EmployeeSsn,PrescribedOn,Refills,Frequency")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", prescription.ItemId);
            ViewData["PatientSsn"] = new SelectList(_context.Patients, "Ssn", "Ssn", prescription.PatientSsn);
            ViewData["PharmacyId"] = new SelectList(_context.Pharmacies, "PharmacyId", "PharmacyId", prescription.PharmacyId);
            return View(prescription);
        }

        // GET: Prescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Prescriptions == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", prescription.ItemId);
            ViewData["PatientSsn"] = new SelectList(_context.Patients, "Ssn", "Ssn", prescription.PatientSsn);
            ViewData["PharmacyId"] = new SelectList(_context.Pharmacies, "PharmacyId", "PharmacyId", prescription.PharmacyId);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrescriptionId,PatientSsn,PharmacyId,ItemId,Quantity,EmployeeSsn,PrescribedOn,Refills,Frequency")] Prescription prescription)
        {
            if (id != prescription.PrescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrescriptionExists(prescription.PrescriptionId))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", prescription.ItemId);
            ViewData["PatientSsn"] = new SelectList(_context.Patients, "Ssn", "Ssn", prescription.PatientSsn);
            ViewData["PharmacyId"] = new SelectList(_context.Pharmacies, "PharmacyId", "PharmacyId", prescription.PharmacyId);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Prescriptions == null)
            {
                return NotFound();
            }

            var prescription = await _context.Prescriptions
                .Include(p => p.Item)
                .Include(p => p.PatientSsnNavigation)
                .Include(p => p.Pharmacy)
                .FirstOrDefaultAsync(m => m.PrescriptionId == id);
            if (prescription == null)
            {
                return NotFound();
            }

            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Prescriptions == null)
            {
                return Problem("Entity set 'ClinicContext.Prescriptions'  is null.");
            }
            var prescription = await _context.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _context.Prescriptions.Remove(prescription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrescriptionExists(int id)
        {
          return (_context.Prescriptions?.Any(e => e.PrescriptionId == id)).GetValueOrDefault();
        }
    }
}
