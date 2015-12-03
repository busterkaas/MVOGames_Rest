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
    public class CrewApplicationsController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private CrewApplicationConverter converter = new CrewApplicationConverter();

        // GET: api/Crews
        public IEnumerable<CrewApplicationDTO> GetCrews()
        {
            var crewApplications = facade.GetCrewApplicationRepository().ReadAll();
            var crewApplicationDTOs = converter.Convert(crewApplications);
            return crewApplicationDTOs;
        }

        // GET: api/Crews/5
        [ResponseType(typeof(CrewApplicationDTO))]
        public IHttpActionResult GetCrew(int id)
        {
            CrewApplication crewApplication = facade.GetCrewApplicationRepository().Find(id);
            var crewApplicationDTO = converter.Convert(crewApplication);
            if (crewApplication == null)
            {
                return NotFound();
            }

            return Ok(crewApplicationDTO);
        }

        // PUT: api/Crews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCrew(int id, CrewApplicationDTO crewApplicationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crewApplicationDTO.Id)
            {
                return BadRequest();
            }
            facade.GetCrewApplicationRepository().Update(converter.Reverse(crewApplicationDTO));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Crews
        [ResponseType(typeof(CrewApplicationDTO))]
        public IHttpActionResult PostCrew(CrewApplicationDTO crewApplication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetCrewApplicationRepository().Add(converter.Reverse(crewApplication));
            return CreatedAtRoute("DefaultApi", new { id = crewApplication.Id }, crewApplication);
        }

        // DELETE: api/Crews/5
        [ResponseType(typeof(CrewApplicationDTO))]
        public IHttpActionResult DeleteCrew(int id)
        {
            CrewApplication crewApplication = facade.GetCrewApplicationRepository().Find(id);
            var crewApplicationDTO = converter.Convert(crewApplication);
            if (crewApplication == null)
            {
                return NotFound();
            }
            
            facade.GetCrewApplicationRepository().Delete(id);

            return Ok(crewApplicationDTO);
        }
    }
}
