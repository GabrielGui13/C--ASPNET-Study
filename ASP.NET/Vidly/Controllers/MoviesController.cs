using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Context;

namespace Vidly.Controllers
{
    public class MoviesController : Controller //cria um controller herdado da classe Controller
    {
        public EFContext db;
        public MoviesController()
        {
            db = new EFContext();
        }
        public ActionResult Index()
        {
            var movieList = db.Movies.Include(m => m.Genre).ToList();

            return View(movieList);
        }
        public ActionResult Details(long id)
        {
            var movie = db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null) return HttpNotFound();

            return View(movie);
        } 

        public ActionResult Create()
        {
            var genres = db.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = db.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie, //populate the form with values included in request data
                    Genres = db.Genres.ToList()
                };

                return View("CustomerForm", viewModel); //basically the same as edit controller, but it's not full
            }

            if (movie.Id == 0)
                db.Movies.Add(movie);
            else
            {
                var movieInDb = db.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            
            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        // GET: Movies/Random
        public ActionResult Random() //cria um action Random para retornar uma view, deve-se criar a view com o mesmo nome
        {
            var movie = new Movie { Name = "Shrek" };

            //ViewData["Movie"] = movie; //old way of passing data, wouuld need to remove movie from View(movie), it's a dictionary
            //ViewBag.Movie = movie; //property added to viewbag at runtime, shouldn't use either of this

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
            };

/*            var viewmodel = new randommovieviewmodel //class added at folder viewmodels
            {
                movie = movie,
                customers = customers
            };*/

            return View(); //returns the view Random.cshtml
        }

/*        public ActionResult Edit(int id) //need to be edit?movieId=1, just edit/1 would crash the app, because in RouteConfig, id is the default
        {
            return Content("id=" + id); //int id comes in the url
        }*/

        // movies
        public ActionResult IndexDemo(int? pageIndex, string sortBy) //string type is a reference type and already nullable
        {
            if (!pageIndex.HasValue) pageIndex = 1; //se nao tem valor, o default eh 1
            if (String.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy)); //by default, 1 and name
        }

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")] //enabled by MapMvcAttributeRoutes()
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}

//ActionResult could be:
//ViewResult / View() = to return a view (razor page)
//PartialViewResult / PartialView() = return a partial ou piece of view
//ContentResult / Content() = simple text
//RedirectResult / Redirect() = redirect the user to an url
//RedirectToRouteResult / RedirectToAction() = redirect to an action instead of an url
//JsonResult / Json() = to return a serialized json object
//FileResult / File() = to return a file
//HttpNotFoundResult / HttpNotFound() = to return a not found error or a 404 error
//EmptyResult = when the action doesn't need to return any values, like void

//return Content("Hello World!"); //returns a simple string
//return HttpNotFound(); //returns a 404 not found error page
//return new EmptyResult(); //there's nothing at the response
//return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" }); //redirects to Index view of Home Controller, passing page and sortby as parameters