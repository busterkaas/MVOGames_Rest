using DTOModels.Models;
using MVOGames_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Converter
{
    public class SuggestionUsersConverter : AbstractDTOConverter<SuggestionUsers, SuggestionUsersDTO>
    {
        public override SuggestionUsersDTO Convert(SuggestionUsers item)
        {
            var suggestionUsersDTO = new SuggestionUsersDTO()
            {
                Id = item.Id,
                CrewGameSuggestionId = item.CrewGameSuggestionId,
                CrewGameSuggestion = new CrewGameSuggestionConverter().Convert(item.CrewGameSuggestion),
                UserId = item.UserId,
                User = new UserConverter().Convert(item.User),
                HasConfirmed = item.HasConfirmed
            };
          
            return suggestionUsersDTO;
        }

        public override SuggestionUsers Reverse(SuggestionUsersDTO item)
        {
            var suggestionUsers = new SuggestionUsers()
            {
                Id = item.Id,
                CrewGameSuggestionId = item.CrewGameSuggestionId,
                CrewGameSuggestion = new CrewGameSuggestionConverter().Reverse(item.CrewGameSuggestion),
                UserId = item.UserId,
                User = new UserConverter().Reverse(item.User),
                HasConfirmed = item.HasConfirmed
            };

            return suggestionUsers;
        }
    }
}

