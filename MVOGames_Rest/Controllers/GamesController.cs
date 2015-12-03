using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
    public class GamesController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private GameConverter converter = new GameConverter();

        // GET: api/Games
        public IEnumerable<GameDTO> GetGames()
        {
            var games = facade.GetGameRepository().ReadAll();
            var gamesDTO = converter.Convert(games);
            return gamesDTO;
        }

        // GET: api/Games/5
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult GetGame(int id)
        {
            Game game = facade.GetGameRepository().Find(id);
            var gameDTO = converter.Convert(game);
            if (game == null)
            {
                return NotFound();
            }

            return Ok(gameDTO);
        }

        // PUT: api/Games/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGame(int id, GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != game.Id)
            {
                return BadRequest();
            }
            facade.GetGameRepository().Update(converter.Reverse(game));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Games
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult PostGame(GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetGameRepository().Add(converter.Reverse(game));
            return CreatedAtRoute("DefaultApi", new { id = game.Id }, game);
        }

        // DELETE: api/Games/5
        [ResponseType(typeof(GameDTO))]
        public IHttpActionResult DeleteGame(int id)
        {
            Game game = facade.GetGameRepository().Find(id);
            var gameDTO = converter.Convert(game);
            if (game == null)
            {
                return NotFound();
            }
            facade.GetGameRepository().Delete(id);

            return Ok(gameDTO);
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool GameExists(int id)
        //{
        //    return db.Games.Count(e => e.Id == id) > 0;
        //}
    }
}