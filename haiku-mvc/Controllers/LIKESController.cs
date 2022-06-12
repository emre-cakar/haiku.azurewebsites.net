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
    public class LIKESController : Controller
    {
        private readonly haiku_mvcContext _context;

        public LIKESController(haiku_mvcContext context)
        {
            _context = context;
        }

        // GET: LIKES
        public async Task<IActionResult> Index()
        {
              return _context.LIKES != null ? 
                          View(await _context.LIKES.ToListAsync()) :
                          Problem("Entity set 'haiku_mvcContext.LIKES'  is null.");
        }

        // GET: LIKES/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LIKES == null)
            {
                return NotFound();
            }

            var lIKES = await _context.LIKES
                .FirstOrDefaultAsync(m => m.LikeId == id);
            if (lIKES == null)
            {
                return NotFound();
            }

            return View(lIKES);
        }

        // GET: LIKES/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LIKES/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LikeId,UserId,UserWhoLiked")] LIKES lIKES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lIKES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lIKES);
        }

        // GET: LIKES/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LIKES == null)
            {
                return NotFound();
            }

            var lIKES = await _context.LIKES.FindAsync(id);
            if (lIKES == null)
            {
                return NotFound();
            }
            return View(lIKES);
        }

        // POST: LIKES/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LikeId,UserId,UserWhoLiked")] LIKES lIKES)
        {
            if (id != lIKES.LikeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lIKES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LIKESExists(lIKES.LikeId))
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
            return View(lIKES);
        }

        // GET: LIKES/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LIKES == null)
            {
                return NotFound();
            }

            var lIKES = await _context.LIKES
                .FirstOrDefaultAsync(m => m.LikeId == id);
            if (lIKES == null)
            {
                return NotFound();
            }

            return View(lIKES);
        }

        // POST: LIKES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LIKES == null)
            {
                return Problem("Entity set 'haiku_mvcContext.LIKES'  is null.");
            }
            var lIKES = await _context.LIKES.FindAsync(id);
            if (lIKES != null)
            {
                _context.LIKES.Remove(lIKES);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LIKESExists(int id)
        {
          return (_context.LIKES?.Any(e => e.LikeId == id)).GetValueOrDefault();
        }
    }
}
