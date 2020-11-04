using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab24_Moviestore.Models;
using Lab24_Moviestore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab24_Moviestore.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Get: Movie
        public async Task<IActionResult> MovieList()
        {
            var movieList = await _context.Movie.ToListAsync();
            return View(movieList);
        }

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

        [HttpGet]
        public async Task<IActionResult> Checkout(Movie movie)
        {
            var movieInfo = await _context.Movie.Where(m => m.Id == movie.Id).ToListAsync();
            return View(movieInfo);
        }
    }
}
