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
    public class UsersController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private UserConverter converter = new UserConverter();

        // GET: api/Users
        public IEnumerable<UserDTO> GetUsers()
        {
            var users = facade.GetUserRepository().ReadAll();
            var usersDTO = converter.Convert(users);
            return usersDTO;
        }

        // GET: api/Users/5
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult GetUser(int id)
        {
            User user = facade.GetUserRepository().Find(id);
            var userDTO = converter.Convert(user);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(userDTO);
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }
            facade.GetUserRepository().Update(converter.Reverse(user));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult PostUser(UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetUserRepository().Add(converter.Reverse(user));
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(UserDTO))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = facade.GetUserRepository().Find(id);
            var userDTO = converter.Convert(user);
            if (user == null)
            {
                return NotFound();
            }
            facade.GetUserRepository().Delete(id);

            return Ok(userDTO);
        }
        
    }
}
