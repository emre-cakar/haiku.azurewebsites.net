using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using haiku_mvc.Data;
using haiku_mvc.Models;

namespace haiku_mvc.Controllers
{
    public class SHARESController : Controller
    {
        private readonly haiku_mvcContext _context;

        public SHARESController(haiku_mvcContext context)
        {
            _context = context;
        }

        // GET: SHARES
        public async Task<IActionResult> Index()
        {
              return _context.SHARES != null ? 
                          View(await _context.SHARES.ToListAsync()) :
                          Problem("Entity set 'haiku_mvcContext.SHARES'  is null.");
        }

        // GET: SHARES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SHARES == null)
            {
                return NotFound();
            }

            var sHARES = await _context.SHARES
                .FirstOrDefaultAsync(m => m.ShareId == id);
            if (sHARES == null)
            {
                return NotFound();
            }

            return View(sHARES);
        }

        // GET: SHARES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SHARES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShareId,UserId,UserWhoShared")] SHARES sHARES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sHARES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sHARES);
        }

        // GET: SHARES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SHARES == null)
            {
                return NotFound();
            }

            var sHARES = await _context.SHARES.FindAsync(id);
            if (sHARES == null)
            {
                return NotFound();
            }
            return View(sHARES);
        }

        // POST: SHARES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShareId,UserId,UserWhoShared")] SHARES sHARES)
        {
            if (id != sHARES.ShareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sHARES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SHARESExists(sHARES.ShareId))
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
            return View(sHARES);
        }

        // GET: SHARES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SHARES == null)
            {
                return NotFound();
            }

            var sHARES = await _context.SHARES
                .FirstOrDefaultAsync(m => m.ShareId == id);
            if (sHARES == null)
            {
                return NotFound();
            }

            return View(sHARES);
        }

        // POST: SHARES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SHARES == null)
            {
                return Problem("Entity set 'haiku_mvcContext.SHARES'  is null.");
            }
            var sHARES = await _context.SHARES.FindAsync(id);
            if (sHARES != null)
            {
                _context.SHARES.Remove(sHARES);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SHARESExists(int id)
        {
          return (_context.SHARES?.Any(e => e.ShareId == id)).GetValueOrDefault();
        }
    }
}
