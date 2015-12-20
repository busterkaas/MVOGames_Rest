using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class PlatformGame
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
