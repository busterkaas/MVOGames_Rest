using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    public class CrewConverter : AbstractDTOConverter<Crew, CrewDTO>
    {
        public override CrewDTO Convert(Crew item)
        {
            var crewDTO = new CrewDTO()
            {
                Id = item.Id,
                Name = item.Name,
                CrewImgUrl = item.CrewImgUrl,
                CrewLeaderId = item.CrewLeaderId
            };
            if (item.Users != null)
            {
                crewDTO.Users = new List<UserDTO>();
                foreach (var user in item.Users)
                {
                    crewDTO.Users.Add(new UserConverter().Convert(user));
                }
            }
            return crewDTO;
        }

        public override Crew Reverse(CrewDTO item)
        {
            var crew = new Crew()
            {
                Id = item.Id,
                Name = item.Name,
                CrewImgUrl = item.CrewImgUrl,
                CrewLeaderId = item.CrewLeaderId
            };
            if (item.Users != null)
            {
                crew.Users = new List<User>();
                foreach (var userDTO in item.Users)
                {
                    crew.Users.Add(new UserConverter().Reverse(userDTO));
                }
            }
            return crew;
        }
    }
}
