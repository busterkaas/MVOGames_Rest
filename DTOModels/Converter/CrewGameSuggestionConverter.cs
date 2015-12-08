using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    public class CrewGameSuggestionConverter : AbstractDTOConverter<CrewGameSuggestion, CrewGameSuggestionDTO>
    {
        public override CrewGameSuggestionDTO Convert(CrewGameSuggestion item)
        {
            var crewGameSuggestionDTO = new CrewGameSuggestionDTO()
            {
                Id = item.Id,
                CrewId = item.CrewId,
                Crew = new CrewConverter().Convert(item.Crew),
                PlatformGameId = item.PlatformGameId,
                PlatformGame = new PlatformGameConverter().Convert(item.PlatformGame),
                ExpirationTime = item.ExpirationTime,
                Discount = item.Discount,
            };
            //crewGameSuggestionDTO.ConfirmedUsers = new List<UserDTO>();
            //if (item.ConfirmedUsers != null)
            //{
            //    foreach (var user in item.ConfirmedUsers)
            //    {
            //        crewGameSuggestionDTO.ConfirmedUsers.Add(new UserConverter().Convert(user));
            //    }
            //}
            return crewGameSuggestionDTO;
        }

        public override CrewGameSuggestion Reverse(CrewGameSuggestionDTO item)
        {
            var crewGameSuggestion = new CrewGameSuggestion()
            {
                Id = item.Id,
                CrewId = item.CrewId,
                Crew = new CrewConverter().Reverse(item.Crew),
                PlatformGameId = item.PlatformGameId,
                PlatformGame = new PlatformGameConverter().Reverse(item.PlatformGame),
                ExpirationTime = item.ExpirationTime,
                Discount = item.Discount,
            };
            //crewGameSuggestion.ConfirmedUsers = new List<User>();
            //if (item.ConfirmedUsers != null)
            //{
            //    foreach (var user in item.ConfirmedUsers)
            //    {
            //        crewGameSuggestion.ConfirmedUsers.Add(new UserConverter().Reverse(user));
            //    }
            //}
            return crewGameSuggestion;

        }
    }
}
