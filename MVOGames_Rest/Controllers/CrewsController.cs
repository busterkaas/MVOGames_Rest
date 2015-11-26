using DTOModels.Converter;
using DTOModels.Models;
using MVOGames_DAL;
using MVOGames_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace MVOGames_Rest.Controllers
{
    public class CrewsController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private CrewConverter gc = new CrewConverter();

        // GET: api/Crews
        public IEnumerable<CrewDTO> GetCrews()
        {
            var crews = facade.GetCrewRepository().ReadAll();
            var crewsDTO = gc.Convert(crews);
            return crewsDTO;
        }

        // GET: api/Crews/5
        [ResponseType(typeof(CrewDTO))]
        public IHttpActionResult GetCrew(int id)
        {
            Crew crew = facade.GetCrewRepository().Find(id);
            var crewDTO = gc.Convert(crew);
            if (crew == null)
            {
                return NotFound();
            }

            return Ok(crewDTO);
        }

        // PUT: api/Crews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCrew(int id, CrewDTO crew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crew.Id)
            {
                return BadRequest();
            }
            facade.GetCrewRepository().Update(gc.Reverse(crew));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Crews
        [ResponseType(typeof(CrewDTO))]
        public IHttpActionResult PostCrew(CrewDTO crew)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetCrewRepository().Add(gc.Reverse(crew));
            return CreatedAtRoute("DefaultApi", new { id = crew.Id }, crew);
        }

        // DELETE: api/Crews/5
        [ResponseType(typeof(CrewDTO))]
        public IHttpActionResult DeleteCrew(int id)
        {
            Crew crew = facade.GetCrewRepository().Find(id);
            var crewDTO = gc.Convert(crew);
            if (crew == null)
            {
                return NotFound();
            }
            facade.GetCrewRepository().Delete(id);

            return Ok(crewDTO);
        }

    }
}
