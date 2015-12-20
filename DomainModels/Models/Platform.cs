using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Platform
    {
        public Platform()
        {
            PGames = new List<PlatformGame>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PlatformGame> PGames { get; set; }
    }
}
