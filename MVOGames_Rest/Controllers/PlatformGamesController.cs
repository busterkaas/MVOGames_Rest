using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DTOModels.Converter;
using DTOModels.Models;
using MVOGames_DAL;
using MVOGames_DAL.Models;

namespace MVOGames_Rest.Controllers
{
    public class PlatformGamesController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private PlatformGameConverter converter = new PlatformGameConverter();

        // GET: api/Genres
        public IEnumerable<PlatformGameDTO> GetPlatformGames()
        {
            var platformgames = facade.GetPlatformGameRepository().ReadAll().ToList();
            var platformgamesDTO = converter.Convert(platformgames);
            return platformgamesDTO;
        }

        // GET: api/Genres/5
        [ResponseType(typeof(PlatformGameDTO))]
        public IHttpActionResult GetPlatformGame(int id)
        {
            PlatformGame platformgame = facade.GetPlatformGameRepository().Find(id);
            var platformgamesDTO = converter.Convert(platformgame);
            if (platformgamesDTO == null)
            {
                return NotFound();
            }

            return Ok(platformgamesDTO);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlatformGame(int id, PlatformGame platformgame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platformgame.Id)
            {
                return BadRequest();
            }
            facade.GetPlatformGameRepository().Update(platformgame);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        [ResponseType(typeof(PlatformGame))]
        public IHttpActionResult PostPlatformGame(PlatformGame platformgame)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetPlatformGameRepository().Add(platformgame);
            return CreatedAtRoute("DefaultApi", new { id = platformgame.Id }, platformgame);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(PlatformGame))]
        public IHttpActionResult DeletePlatformGame(int id)
        {
            PlatformGame platformgame = facade.GetPlatformGameRepository().Find(id);
            //var genreDTO = gc.Convert(genre);
            if (platformgame == null)
            {
                return NotFound();
            }
            facade.GetPlatformGameRepository().Delete(id);

            return Ok(platformgame);
        }
    }
}
