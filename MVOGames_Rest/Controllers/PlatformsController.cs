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
    public class PlatformsController : ApiController
    {
        private DALFacade facade = new DALFacade();
        private PlatformConverter gc = new PlatformConverter();

        // GET: api/Platforms
        public IEnumerable<PlatformDTO> GetPlatforms()
        {
            var platforms = facade.GetPlatformRepository().ReadAll();
            var platformsDTO = gc.Convert(platforms);
            return platformsDTO;
        }

        // GET: api/Platforms/5
        [ResponseType(typeof(PlatformDTO))]
        public IHttpActionResult GetPlatform(int id)
        {
            Platform platform = facade.GetPlatformRepository().Find(id);
            var platformDTO = gc.Convert(platform);
            if (platform == null)
            {
                return NotFound();
            }

            return Ok(platformDTO);
        }

        // PUT: api/Platforms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlatform(int id, PlatformDTO platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != platform.Id)
            {
                return BadRequest();
            }
            facade.GetPlatformRepository().Update(gc.Reverse(platform));

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Platforms
        [ResponseType(typeof(PlatformDTO))]
        public IHttpActionResult PostPlatform(PlatformDTO platform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            facade.GetPlatformRepository().Add(gc.Reverse(platform));
            return CreatedAtRoute("DefaultApi", new { id = platform.Id }, platform);
        }

        // DELETE: api/Platforms/5
        [ResponseType(typeof(PlatformDTO))]
        public IHttpActionResult DeletePlatform(int id)
        {
            Platform platform = facade.GetPlatformRepository().Find(id);
            var platformDTO = gc.Convert(platform);
            if (platform == null)
            {
                return NotFound();
            }
            facade.GetPlatformRepository().Delete(id);

            return Ok(platformDTO);
        }

    }
}
