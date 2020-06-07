using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Controllers.Data;
using Library.Models;

namespace Library.Controllers
{
    public class BooklistController : Controller
    {
        private readonly LibraryContext _context;

        public BooklistController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Booklist
        public async Task<IActionResult> Index(string searchString)
        {
            var booklist = from m in _context.Booklist
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                booklist = booklist.Where(s => s.BookName.Contains(searchString));
            }


            return View(await booklist.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        // GET: Booklist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booklist = await _context.Booklist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booklist == null)
            {
                return NotFound();
            }

            return View(booklist);
        }

        // GET: Booklist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Booklist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BookName,Author,Genre")] Booklist booklist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booklist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(booklist);
        }

        // GET: Booklist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booklist = await _context.Booklist.FindAsync(id);
            if (booklist == null)
            {
                return NotFound();
            }
            return View(booklist);
        }

        // POST: Booklist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BookName,Author,Genre")] Booklist booklist)
        {
            if (id != booklist.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booklist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BooklistExists(booklist.Id))
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
            return View(booklist);
        }

        // GET: Booklist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booklist = await _context.Booklist
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booklist == null)
            {
                return NotFound();
            }

            return View(booklist);
        }

        // POST: Booklist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booklist = await _context.Booklist.FindAsync(id);
            _context.Booklist.Remove(booklist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BooklistExists(int id)
        {
            return _context.Booklist.Any(e => e.Id == id);
        }
    }
}
