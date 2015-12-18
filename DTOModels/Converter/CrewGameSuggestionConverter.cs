using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using DomainModels.Models;

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
                ExpirationDate = item.ExpirationDate,
                ExpirationTime = item.ExpirationTime,
                Discount = item.Discount,
            };
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
                ExpirationDate = item.ExpirationDate,
                ExpirationTime = item.ExpirationTime,
                Discount = item.Discount,
            };
            return crewGameSuggestion;

        }
    }
}
