using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGamesDAL.Models;

namespace DTOModels.Converter
{
    public class GenreConverter : AbstractDTOConverter<Genre, GenreDTO>
    {
        public override GenreDTO Convert(Genre item)
        {
            var genreDTO = new GenreDTO()
            {
                Id = item.Id,
                Name = item.Name
            };
            return genreDTO;
        }

        public override Genre Reverse(GenreDTO item)
        {
            var genre = new Genre()
            {
                Id = item.Id,
                Name = item.Name
            };
            return genre;
        }
    }
}
