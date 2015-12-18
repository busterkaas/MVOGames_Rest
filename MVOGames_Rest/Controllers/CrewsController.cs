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
    public class CrewsController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private CrewConverter converter = new CrewConverter();

        // GET: api/Crews
        public IEnumerable<CrewDTO> GetCrews()
        {
            var crews = facade.GetCrewRepository().ReadAll();
            var crewsDTO = converter.Convert(crews);
            return crewsDTO;
        }

        // GET: api/Crews/5
        [ResponseType(typeof(CrewDTO))]
        public IHttpActionResult GetCrew(int id)
        {
            Crew crew = facade.GetCrewRepository().Find(id);
            var crewDTO = converter.Convert(crew);
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
            facade.GetCrewRepository().Update(converter.Reverse(crew));

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
            facade.GetCrewRepository().Add(converter.Reverse(crew));
            return CreatedAtRoute("DefaultApi", new { id = crew.Id }, crew);
        }

        // DELETE: api/Crews/5
        [ResponseType(typeof(CrewDTO))]
        public IHttpActionResult DeleteCrew(int id)
        {
            Crew crew = facade.GetCrewRepository().Find(id);
            var crewDTO = converter.Convert(crew);
            if (crew == null)
            {
                return NotFound();
            }
            facade.GetCrewRepository().Delete(id);

            return Ok(crewDTO);
        }

    }
}
