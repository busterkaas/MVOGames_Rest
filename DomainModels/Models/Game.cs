using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
    public class Game
    {
        public Game()
        {
            GPlatforms = new List<PlatformGame>();
            Genres = new List<Genre>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }
        public List<PlatformGame> GPlatforms { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
