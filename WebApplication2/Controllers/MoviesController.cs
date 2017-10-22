using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviePro.Models;
using MoviePro.ViewModels;

namespace MoviePro.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "shrek!" };
          //  var customers = new List<Customers>
            {
                //new Customers {CustomerName = "customer 1" },
              //  new Customers {CustomerName = "customer 2" }
            };
            var viewModel = new RandomMovieViewModle {
                Movie = movie,
                //Customers = customers
            };
            return View(viewModel);

        }
    }
}