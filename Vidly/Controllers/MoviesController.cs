using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //// GET: Movies
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Somethxdvzsdxvsvfving" };

            //ViewData["Movie"] = movie;
            //ViewData["test"] = "test case";
            //ViewBag.test1 = "test view bag";
            //return View(view);
            //return new ViewResult(movie);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new{page=1, sortBy="name"});

            var customers = new List<Customer>()
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
             
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);

        }

        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie { Id = 1, Name = "Prisoner"},
                new Movie { Id = 2, Name = "Lord of the Ring"},
                new Movie { Id = 3, Name = "Olympus has Fallen"}
            };
            return View(movies);
        }

        public ActionResult Details()
        {
            return View();
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year+"/"+month);
        }
    }
}