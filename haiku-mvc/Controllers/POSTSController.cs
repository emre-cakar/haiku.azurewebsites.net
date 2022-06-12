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
    public class POSTSController : Controller
    {
        private readonly haiku_mvcContext _context;

        public POSTSController(haiku_mvcContext context)
        {
            _context = context;
        }

        // GET: POSTS
        public async Task<IActionResult> Index()
        {
              return _context.POSTS != null ? 
                          View(await _context.POSTS.ToListAsync()) :
                          Problem("Entity set 'haiku_mvcContext.POSTS'  is null.");
        }

        // GET: POSTS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.POSTS == null)
            {
                return NotFound();
            }

            var pOSTS = await _context.POSTS
                .FirstOrDefaultAsync(m => m.HaikuId == id);
            if (pOSTS == null)
            {
                return NotFound();
            }

            return View(pOSTS);
        }

        // GET: POSTS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: POSTS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HaikuId,AuthorId,Contents,Date,Likes,Shares")] POSTS pOSTS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pOSTS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pOSTS);
        }

        // GET: POSTS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.POSTS == null)
            {
                return NotFound();
            }

            var pOSTS = await _context.POSTS.FindAsync(id);
            if (pOSTS == null)
            {
                return NotFound();
            }
            return View(pOSTS);
        }

        // POST: POSTS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HaikuId,AuthorId,Contents,Date,Likes,Shares")] POSTS pOSTS)
        {
            if (id != pOSTS.HaikuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pOSTS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!POSTSExists(pOSTS.HaikuId))
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
            return View(pOSTS);
        }

        // GET: POSTS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.POSTS == null)
            {
                return NotFound();
            }

            var pOSTS = await _context.POSTS
                .FirstOrDefaultAsync(m => m.HaikuId == id);
            if (pOSTS == null)
            {
                return NotFound();
            }

            return View(pOSTS);
        }

        // POST: POSTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.POSTS == null)
            {
                return Problem("Entity set 'haiku_mvcContext.POSTS'  is null.");
            }
            var pOSTS = await _context.POSTS.FindAsync(id);
            if (pOSTS != null)
            {
                _context.POSTS.Remove(pOSTS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool POSTSExists(int id)
        {
          return (_context.POSTS?.Any(e => e.HaikuId == id)).GetValueOrDefault();
        }
    }
}
