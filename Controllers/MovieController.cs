using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab24_Moviestore.Models;
using Lab24_Moviestore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

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
            var movieInfo = await _context.Movie.FirstOrDefaultAsync(m => m.Id == movie.Id);
            return View(movieInfo);
        }

        public async Task<IActionResult> CheckoutMovie(Movie movie)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var dueDate = DateTime.Now.AddDays(7);
            var checkoutOutMovie = new CheckedOutMovies()
            {
                UserId = userId,
                DueDate = dueDate
            };
            _context.CheckedOutMovie.Add(checkoutOutMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MovieList));
        }
    }
}
