using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab24_Bookstore.Data;
using Lab24_Bookstore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab24_Bookstore.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Registration()
        {
            return View();
        }

        //Get: Movie
        public async Task<IActionResult> MovieList()
        {
            var movieList = await _context.Movie.ToListAsync();
            return View(movieList);
        }
        
        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Genre,Runtime")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(MovieList));
            }
            return View(movie);
        }
    }
}
