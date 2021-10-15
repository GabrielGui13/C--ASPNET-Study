using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller //cria um controller herdado da classe Controller
    {
        // GET: Movies/Random
        public ActionResult Random() //cria um controller Random para retornar uma view, deve-se criar a view com o mesmo nome
        {
            var movie = new Movie { Name = "Shrek" };

            return View(movie);
        }
    }
}