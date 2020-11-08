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
using Newtonsoft.Json;

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
            var checkedOutMovies = await _context.CheckedOutMovie.ToListAsync();
            var masterMovieList = new List<MovieCheckoutData>();

            foreach(var movie in movieList)
            {
                var movieCheckoutData = new MovieCheckoutData();
                var checkedOutMovie = checkedOutMovies.FirstOrDefault(c => c.MovieId == movie.Id);
                if (checkedOutMovie != null)
                {
                    movieCheckoutData.IsCheckedOut = true;
                    movieCheckoutData.DueDate = checkedOutMovie.DueDate;
                }
                movieCheckoutData.Movies = movie;
                masterMovieList.Add(movieCheckoutData);
            }
            return View(masterMovieList);
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
            var dueDate = DateTime.Now.AddDays(7).Date;
            var checkoutMovie = new CheckedOutMovies()
            {
                UserId = userId,
                DueDate = dueDate,
                MovieId = movie.Id
                
            };
            _context.CheckedOutMovie.Add(checkoutMovie);            
            await _context.SaveChangesAsync();

            var checkOutMovie = new MovieListAndCheckout
            {
                MovieTitle = movie.Title,
                MovieDueDate = checkoutMovie.DueDate
            };

            TempData["CheckedOutMovie"] = JsonConvert.SerializeObject(checkOutMovie);

            return RedirectToAction("Result", "Movie");
        }

        public IActionResult Result()
        {
            var result = JsonConvert.DeserializeObject<MovieListAndCheckout>((string)TempData["CheckedOutMovie"]);

            return View(result);
        }

        public async Task<IActionResult> CheckedOutMovie()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _context.CheckedOutMovie.Include(m => m.Movie).Where(m => m.UserId == userId).ToListAsync();
            return View(result);
        }


        public async Task<IActionResult> Checkin(CheckedOutMovies checkedOutMovie)
        {
            var returnMovie = await _context.CheckedOutMovie.FirstOrDefaultAsync(m => m.Id == checkedOutMovie.Id);
            _context.CheckedOutMovie.Remove(returnMovie);
            await _context.SaveChangesAsync();
            return RedirectToAction("CheckedOutMovie", "Movie");
        }
    }
}
