using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Models
{
    public class CrewGameSuggestion
    {
        public int Id { get; set; }
        public int CrewId { get; set; }
        public virtual Crew Crew { get; set; }
        public int PlatformGameId { get; set; }
        public virtual PlatformGame PlatformGame { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public decimal Discount { get; set; }
        public DateTime ExpirationTime { get; set; }
        public virtual List<User> ConfirmedUsers { get; set; }

    }
}
