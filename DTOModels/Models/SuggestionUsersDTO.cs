using MVOGames_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class SuggestionUsersDTO
    {
        public int Id { get; set; }
        public int CrewGameSuggestionId { get; set; }
        public CrewGameSuggestion CrewGameSuggestion { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public bool HasConfirmed { get; set; }
    }
}
