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
    public class USERSController : Controller
    {
        private readonly haiku_mvcContext _context;

        public USERSController(haiku_mvcContext context)
        {
            _context = context;
        }

        // GET: USERS
        public async Task<IActionResult> Index()
        {
              return _context.USERS != null ? 
                          View(await _context.USERS.ToListAsync()) :
                          Problem("Entity set 'haiku_mvcContext.USERS'  is null.");
        }

        // GET: USERS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.USERS == null)
            {
                return NotFound();
            }

            var uSERS = await _context.USERS
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (uSERS == null)
            {
                return NotFound();
            }

            return View(uSERS);
        }

        // GET: USERS/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: USERS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,NameSurname,UserName,Email,Password,TotalFollowers,TotalFollows,TotalHaiku,TotalLikes,TotalShares")] USERS uSERS)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uSERS);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uSERS);
        }

        // GET: USERS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.USERS == null)
            {
                return NotFound();
            }

            var uSERS = await _context.USERS.FindAsync(id);
            if (uSERS == null)
            {
                return NotFound();
            }
            return View(uSERS);
        }

        // POST: USERS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,NameSurname,UserName,Email,Password,TotalFollowers,TotalFollows,TotalHaiku,TotalLikes,TotalShares")] USERS uSERS)
        {
            if (id != uSERS.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uSERS);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!USERSExists(uSERS.UserId))
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
            return View(uSERS);
        }

        // GET: USERS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.USERS == null)
            {
                return NotFound();
            }

            var uSERS = await _context.USERS
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (uSERS == null)
            {
                return NotFound();
            }

            return View(uSERS);
        }

        // POST: USERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.USERS == null)
            {
                return Problem("Entity set 'haiku_mvcContext.USERS'  is null.");
            }
            var uSERS = await _context.USERS.FindAsync(id);
            if (uSERS != null)
            {
                _context.USERS.Remove(uSERS);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool USERSExists(int id)
        {
          return (_context.USERS?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
