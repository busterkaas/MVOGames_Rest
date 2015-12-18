using DomainModels.Models;
using DTOModels.Converter;
using DTOModels.Models;
using MVOGames_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVOGames_Rest.Controllers
{
    public class GenresController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private GenreConverter converter = new GenreConverter();

        // GET: api/Genres
        public IEnumerable<GenreDTO> GetGenres()
        {
            var genres = facade.GetGenreRepository().ReadAll();
            var genresDTO = converter.Convert(genres);
            return genresDTO;
        }

        // GET: api/Genres/5
        [ResponseType(typeof(GenreDTO))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = facade.GetGenreRepository().Find(id);
            var genreDTO = converter.Convert(genre);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genreDTO);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, GenreDTO genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.Id)
            {
                return BadRequest();
            }
            facade.GetGenreRepository().Update(converter.Reverse(genre));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        [ResponseType(typeof(GenreDTO))]
        public IHttpActionResult PostGenre(GenreDTO genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetGenreRepository().Add(converter.Reverse(genre));
            return CreatedAtRoute("DefaultApi", new { id = genre.Id }, genre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(GenreDTO))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = facade.GetGenreRepository().Find(id);
            var genreDTO = converter.Convert(genre);
            if (genre == null)
            {
                return NotFound();
            }
            facade.GetGenreRepository().Delete(id);

            return Ok(genreDTO);
        }

    }
}
