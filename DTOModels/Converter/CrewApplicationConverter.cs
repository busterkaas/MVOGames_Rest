using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using DomainModels.Models;

namespace DTOModels.Converter
{
    public class CrewApplicationConverter : AbstractDTOConverter<CrewApplication, CrewApplicationDTO>
    {
        public override CrewApplicationDTO Convert(CrewApplication item)
        {
            var crewApplicationDTO = new CrewApplicationDTO()
            {
                Id= item.Id,
              CrewId = item.CrewId,
              UserId = item.UserId,
             User = new UserConverter().Convert(item.User),
             Crew = new CrewConverter().Convert(item.Crew)
            };
           
            return crewApplicationDTO;
        }

        public override CrewApplication Reverse(CrewApplicationDTO item)
        {
            var crewApplication = new CrewApplication()
            {
                Id=item.Id,
                CrewId = item.CrewId,
                UserId = item.UserId,
                User = new UserConverter().Reverse(item.User),
                Crew = new CrewConverter().Reverse(item.Crew)
            };

            return crewApplication;

        }
    }
}
