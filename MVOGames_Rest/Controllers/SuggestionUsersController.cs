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
    public class SuggestionUsersController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private SuggestionUsersConverter converter = new SuggestionUsersConverter();

        // GET: api/Crews
        public IEnumerable<SuggestionUsersDTO> GetSuggestionUsers()
        {
            var suggestionUsers = facade.GetSuggestionUsersRepository().ReadAll();
            var suggestionUsersDTOs = converter.Convert(suggestionUsers);
            return suggestionUsersDTOs;
        }

        // GET: api/Crews/5
        [ResponseType(typeof(SuggestionUsersDTO))]
        public IHttpActionResult GetSuggestionUsers(int id)
        {
            SuggestionUsers suggestionUsers = facade.GetSuggestionUsersRepository().Find(id);
            var suggestionUsersDTO = converter.Convert(suggestionUsers);
            if (suggestionUsers == null)
            {
                return NotFound();
            }

            return Ok(suggestionUsersDTO);
        }

        // PUT: api/Crews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSuggestionUsers(int id, SuggestionUsersDTO suggestionUsersDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != suggestionUsersDTO.Id)
            {
                return BadRequest();
            }
            facade.GetSuggestionUsersRepository().Update(converter.Reverse(suggestionUsersDTO));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Crews
        [ResponseType(typeof(SuggestionUsersDTO))]
        public IHttpActionResult PostGameCrewSuggestion(SuggestionUsersDTO suggestionUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetSuggestionUsersRepository().Add(converter.Reverse(suggestionUsers));
            return CreatedAtRoute("DefaultApi", new { id = suggestionUsers.Id }, suggestionUsers);
        }

        // DELETE: api/Crews/5
        [ResponseType(typeof(SuggestionUsersDTO))]
        public IHttpActionResult DeleteSuggestionUsers(int id)
        {
            SuggestionUsers suggestionUsers = facade.GetSuggestionUsersRepository().Find(id);
            var suggestionUsersDTO = converter.Convert(suggestionUsers);
            if (suggestionUsers == null)
            {
                return NotFound();
            }

            facade.GetSuggestionUsersRepository().Delete(id);

            return Ok(suggestionUsers);
        }
    }
}

