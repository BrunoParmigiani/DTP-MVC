using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DTP.Data;
using DTP.Models;

namespace DTP.Controllers
{
    public class SitesController : Controller
    {
        private readonly DTPContext _context;

        public SitesController(DTPContext context)
        {
            _context = context;
        }

        // GET: Sites
        public async Task<IActionResult> Index()
        {
              return _context.Sites != null ? 
                          View(await _context.Sites.ToListAsync()) :
                          Problem("Entity set 'DTPContext.Sites'  is null.");
        }

        // GET: Sites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var sites = await _context.Sites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sites == null)
            {
                return NotFound();
            }

            return View(sites);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Link")] Sites sites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sites);
        }

        // GET: Sites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var sites = await _context.Sites.FindAsync(id);
            if (sites == null)
            {
                return NotFound();
            }
            return View(sites);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Link")] Sites sites)
        {
            if (id != sites.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SitesExists(sites.Id))
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
            return View(sites);
        }

        // GET: Sites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sites == null)
            {
                return NotFound();
            }

            var sites = await _context.Sites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sites == null)
            {
                return NotFound();
            }

            return View(sites);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sites == null)
            {
                return Problem("Entity set 'DTPContext.Sites'  is null.");
            }
            var sites = await _context.Sites.FindAsync(id);
            if (sites != null)
            {
                _context.Sites.Remove(sites);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SitesExists(int id)
        {
          return (_context.Sites?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
