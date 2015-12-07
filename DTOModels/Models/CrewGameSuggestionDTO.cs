using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class CrewGameSuggestionDTO
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public CrewDTO Crew { get; set; }
        public int PlatformGameId { get; set; }
        public PlatformGameDTO PlatformGame { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}
