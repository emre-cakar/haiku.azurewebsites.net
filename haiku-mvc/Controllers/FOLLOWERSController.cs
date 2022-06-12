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
    public class FOLLOWERSController : Controller
    {
        private readonly haiku_mvcContext _context;

        public FOLLOWERSController(haiku_mvcContext context)
        {
            _context = context;
        }

        // GET: FOLLOWERS
        public async Task<IActionResult> Index()
        {
              return _context.FOLLOWERS != null ? 
                          View(await _context.FOLLOWERS.ToListAsync()) :
                          Problem("Entity set 'haiku_mvcContext.FOLLOWERS'  is null.");
        }

        // GET: FOLLOWERS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FOLLOWERS == null)
            {
                return NotFound();
            }

            var fOLLOWERS = await _context.FOLLOWERS
                .FirstOrDefaultAsync(m => m.FollowId == id);
            if (fOLLOWERS == null)
            {
                return NotFound();
            }

            return View(fOLLOWERS);
        }

        // GET: FOLLOWERS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FOLLOWERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FollowId,UserId,UserWhoFollowed")] FOLLOWERS fOLLOWERS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fOLLOWERS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fOLLOWERS);
        }

        // GET: FOLLOWERS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FOLLOWERS == null)
            {
                return NotFound();
            }

            var fOLLOWERS = await _context.FOLLOWERS.FindAsync(id);
            if (fOLLOWERS == null)
            {
                return NotFound();
            }
            return View(fOLLOWERS);
        }

        // POST: FOLLOWERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FollowId,UserId,UserWhoFollowed")] FOLLOWERS fOLLOWERS)
        {
            if (id != fOLLOWERS.FollowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fOLLOWERS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FOLLOWERSExists(fOLLOWERS.FollowId))
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
            return View(fOLLOWERS);
        }

        // GET: FOLLOWERS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FOLLOWERS == null)
            {
                return NotFound();
            }

            var fOLLOWERS = await _context.FOLLOWERS
                .FirstOrDefaultAsync(m => m.FollowId == id);
            if (fOLLOWERS == null)
            {
                return NotFound();
            }

            return View(fOLLOWERS);
        }

        // POST: FOLLOWERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FOLLOWERS == null)
            {
                return Problem("Entity set 'haiku_mvcContext.FOLLOWERS'  is null.");
            }
            var fOLLOWERS = await _context.FOLLOWERS.FindAsync(id);
            if (fOLLOWERS != null)
            {
                _context.FOLLOWERS.Remove(fOLLOWERS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FOLLOWERSExists(int id)
        {
          return (_context.FOLLOWERS?.Any(e => e.FollowId == id)).GetValueOrDefault();
        }
    }
}
