using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Models
{
    public class Game
    {
        public Game()
        {
            GPlatforms = new List<PlatformGame>();
            Genres = new List<Genre>();
        }
        public int Id { get; set; }
        [Required(ErrorMessage = "A Title is required!")]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string CoverUrl { get; set; }
        public string TrailerUrl { get; set; }
        public string Description { get; set; }
        public virtual List<PlatformGame> GPlatforms { get; set; }
        public virtual List<Genre> Genres { get; set; }
    }
}
