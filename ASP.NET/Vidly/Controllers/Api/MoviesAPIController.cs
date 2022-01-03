using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.Models;
using Vidly.Dtos;
using Vidly.ViewModels;
using Vidly.Context;
using AutoMapper;

//controller normal
//baixar as dependencias webhost e webapi
//um arquivo webapiconfig.cs precisa ser criado em App_Start
//precisa inicializar a config de web api em Global.asax
//dependencias importantes => System.Net; System.Net.Http; System.Web; System.Web.Http; System.Web.Optimization; System.Web.Routing;

//automapper
// baixar a dependencia automapper -version:4.1.0
//criar o arquivo mappingprofile no app_start e criar os mapeamentos
//inicializar o profile no Global.asax
//apos isso pode usar normal

namespace Vidly.Controllers
{
    //works because we created a WebApiConfig.cs in App_start and initialized in Global.asax
    public class MoviesAPIController : ApiController //works like an api because inherit ApiController
    {
        private EFContext db;

        public MoviesAPIController()
        {
            db = new EFContext();
        }

        // GET api/moviesapi
        public IHttpActionResult GetMovies()
        {
            return Ok(db.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>)); //recebeu movies da database e mapeou em moviesdto
        }
        
        // GET api/moviesapi/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            var movieMap = Mapper.Map<Movie, MovieDto>(movie); //recebeu um movie da database e mapeou em um moviedto

            return Ok(movieMap);
        }

        // POST api/moviesapi
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto) //error ocurred cause moviedto was internal and not public
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto); //recebeu um moviedto da request e mapeou em um movie para a database
            db.Movies.Add(movie);
            db.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // PUT api/moviesapi/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = db.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                return NotFound();

            Mapper.Map(movieDto, movieInDb);

            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = db.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            db.Movies.Remove(movieInDb);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}