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
using DomainModels.Models;

namespace MVOGames_Rest.Controllers
{
    public class CrewGameSuggestionsController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private CrewGameSuggestionConverter converter = new CrewGameSuggestionConverter();

        // GET: api/Crews
        public IEnumerable<CrewGameSuggestionDTO> GetGameCrewSuggestions()
        {
            var crewGameSuggestions = facade.GetCGSRepository().ReadAll();
            var crewGameSuggestionsDTOs = converter.Convert(crewGameSuggestions);
            return crewGameSuggestionsDTOs;
        }

        // GET: api/Crews/5
        [ResponseType(typeof(CrewGameSuggestionDTO))]
        public IHttpActionResult GetGameCrewSuggestion(int id)
        {
            CrewGameSuggestion crewGameSuggestion = facade.GetCGSRepository().Find(id);
            var crewGameSuggestionDTO = converter.Convert(crewGameSuggestion);
            if (crewGameSuggestion == null)
            {
                return NotFound();
            }

            return Ok(crewGameSuggestionDTO);
        }

        // PUT: api/Crews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGameCrewSuggestion(int id, CrewGameSuggestionDTO crewGameSuggestionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crewGameSuggestionDTO.Id)
            {
                return BadRequest();
            }
            facade.GetCGSRepository().Update(converter.Reverse(crewGameSuggestionDTO));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Crews
        [ResponseType(typeof(CrewGameSuggestionDTO))]
        public IHttpActionResult PostGameCrewSuggestion(CrewGameSuggestionDTO crewGameSuggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetCGSRepository().Add(converter.Reverse(crewGameSuggestion));
            return CreatedAtRoute("DefaultApi", new { id = crewGameSuggestion.Id }, crewGameSuggestion);
        }

        // DELETE: api/Crews/5
        [ResponseType(typeof(CrewGameSuggestionDTO))]
        public IHttpActionResult DeleteGameCrewSuggestion(int id)
        {
            CrewGameSuggestion crewGameSuggestion = facade.GetCGSRepository().Find(id);
            var crewGameSuggestionDTO = converter.Convert(crewGameSuggestion);
            if (crewGameSuggestion == null)
            {
                return NotFound();
            }

            facade.GetCGSRepository().Delete(id);

            return Ok(crewGameSuggestion);
        }
    }
}
