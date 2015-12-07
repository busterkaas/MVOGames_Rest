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
    public class RolesController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private RoleConverter converter = new RoleConverter();

        // GET: api/Roles
        public IEnumerable<RoleDTO> GetRoles()
        {
            var roles = facade.GetRoleRepository().ReadAll();
            var rolesDTO = converter.Convert(roles);
            return rolesDTO;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(RoleDTO))]
        public IHttpActionResult GetRole(int id)
        {
            Role role = facade.GetRoleRepository().Find(id);
            var roleDTO = converter.Convert(role);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(roleDTO);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRole(int id, Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != role.Id)
            {
                return BadRequest();
            }
            facade.GetRoleRepository().Update(role);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Roles
        [ResponseType(typeof(Role))]
        public IHttpActionResult PostRole(Role role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetRoleRepository().Add(role);
            return CreatedAtRoute("DefaultApi", new { id = role.Id }, role);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(Role))]
        public IHttpActionResult DeleteRole(int id)
        {
            Role role = facade.GetRoleRepository().Find(id);
           
            if (role == null)
            {
                return NotFound();
            }
            facade.GetRoleRepository().Delete(id);
            
            return Ok(role);
        }

    }
}
