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
    public class BlogpostController : Controller
    {
        private readonly LibraryContext _context;

        public BlogpostController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Blogpost
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogpost.ToListAsync());
        }

        // GET: Blogpost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogpost
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blogpost == null)
            {
                return NotFound();
            }

            return View(blogpost);
        }

        // GET: Blogpost/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogpost/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Subject,Text,Posted")] Blogpost blogpost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogpost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogpost);
        }

        // GET: Blogpost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogpost.FindAsync(id);
            if (blogpost == null)
            {
                return NotFound();
            }
            return View(blogpost);
        }

        // POST: Blogpost/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Subject,Text,Posted")] Blogpost blogpost)
        {
            if (id != blogpost.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogpost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogpostExists(blogpost.BlogId))
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
            return View(blogpost);
        }

        // GET: Blogpost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogpost = await _context.Blogpost
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blogpost == null)
            {
                return NotFound();
            }

            return View(blogpost);
        }

        // POST: Blogpost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogpost = await _context.Blogpost.FindAsync(id);
            _context.Blogpost.Remove(blogpost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogpostExists(int id)
        {
            return _context.Blogpost.Any(e => e.BlogId == id);
        }
    }
}
