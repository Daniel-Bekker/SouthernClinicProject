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
    public class ItemSuppliersController : Controller
    {
        private readonly ClinicContext _context;

        public ItemSuppliersController(ClinicContext context)
        {
            _context = context;
        }

        // GET: ItemSuppliers
        public async Task<IActionResult> Index()
        {
            var clinicContext = _context.ItemSuppliers.Include(i => i.Item).Include(i => i.Supplier);
            return View(await clinicContext.ToListAsync());
        }

        // GET: ItemSuppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemSuppliers == null)
            {
                return NotFound();
            }

            var itemSupplier = await _context.ItemSuppliers
                .Include(i => i.Item)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (itemSupplier == null)
            {
                return NotFound();
            }

            return View(itemSupplier);
        }

        // GET: ItemSuppliers/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId");
            return View();
        }

        // POST: ItemSuppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupplierId,ItemId,Quantity,UnitPrice")] ItemSupplier itemSupplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemSupplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", itemSupplier.ItemId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", itemSupplier.SupplierId);
            return View(itemSupplier);
        }

        // GET: ItemSuppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemSuppliers == null)
            {
                return NotFound();
            }

            var itemSupplier = await _context.ItemSuppliers.FindAsync(id);
            if (itemSupplier == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", itemSupplier.ItemId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", itemSupplier.SupplierId);
            return View(itemSupplier);
        }

        // POST: ItemSuppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupplierId,ItemId,Quantity,UnitPrice")] ItemSupplier itemSupplier)
        {
            if (id != itemSupplier.SupplierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemSupplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemSupplierExists(itemSupplier.SupplierId))
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
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "ItemId", itemSupplier.ItemId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "SupplierId", itemSupplier.SupplierId);
            return View(itemSupplier);
        }

        // GET: ItemSuppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemSuppliers == null)
            {
                return NotFound();
            }

            var itemSupplier = await _context.ItemSuppliers
                .Include(i => i.Item)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.SupplierId == id);
            if (itemSupplier == null)
            {
                return NotFound();
            }

            return View(itemSupplier);
        }

        // POST: ItemSuppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemSuppliers == null)
            {
                return Problem("Entity set 'ClinicContext.ItemSuppliers'  is null.");
            }
            var itemSupplier = await _context.ItemSuppliers.FindAsync(id);
            if (itemSupplier != null)
            {
                _context.ItemSuppliers.Remove(itemSupplier);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemSupplierExists(int id)
        {
          return (_context.ItemSuppliers?.Any(e => e.SupplierId == id)).GetValueOrDefault();
        }
    }
}
