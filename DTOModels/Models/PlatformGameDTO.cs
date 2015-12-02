using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Models
{
    public class PlatformGameDTO
    {
        public int GameId { get; set; }
        public GameDTO Game { get; set; }
        public int PlatformId { get; set; }
        public PlatformDTO Platform { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
