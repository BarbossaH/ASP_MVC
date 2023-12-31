using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMVC.Models;
using CMVC.DataAccess.Context;

namespace CMVC.Views
{
    public class ItemCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItemCategory
        public async Task<IActionResult> Index()
        {
              return _context.ItemCategories != null ? 
                          View(await _context.ItemCategories.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ItemCategories'  is null.");
        }

        // GET: ItemCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItemCategories == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // GET: ItemCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItemCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Order,Gender")] ItemCategory itemCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itemCategory);
        }

        // GET: ItemCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItemCategories == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory == null)
            {
                return NotFound();
            }
            return View(itemCategory);
        }

        // POST: ItemCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Order,Gender")] ItemCategory itemCategory)
        {
            if (id != itemCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCategoryExists(itemCategory.Id))
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
            return View(itemCategory);
        }

        // GET: ItemCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItemCategories == null)
            {
                return NotFound();
            }

            var itemCategory = await _context.ItemCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCategory == null)
            {
                return NotFound();
            }

            return View(itemCategory);
        }

        // POST: ItemCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItemCategories == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItemCategories'  is null.");
            }
            var itemCategory = await _context.ItemCategories.FindAsync(id);
            if (itemCategory != null)
            {
                _context.ItemCategories.Remove(itemCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCategoryExists(int id)
        {
          return (_context.ItemCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
