using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    public class GameConverter : AbstractDTOConverter<Game, GameDTO>
    {
        public override GameDTO Convert(Game item)
        {
            var gameDTO = new GameDTO()
            {
               Id = item.Id,
               Title = item.Title,
               Description = item.Description,
               CoverUrl = item.CoverUrl,
               TrailerUrl = item.TrailerUrl
            };
            gameDTO.Genres = new List<GenreDTO>();
            if (item.Genres != null)
            {
                foreach (var genre in item.Genres)
                {
                    //gameDTO.Genres.Add(new GenreConverter().Convert(genre));
                    gameDTO.Genres.Add(new GenreDTO()
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    });
                }
            }
            gameDTO.GPlatforms = new List<PlatformGameDTO>();
            if (item.GPlatforms != null)
            {
                foreach (var gPlatform in item.GPlatforms)
                {
                    gameDTO.GPlatforms.Add(new PlatformGameDTO()
                    {
                        GameId = gPlatform.GameId,
                        PlatformId = gPlatform.PlatformId,
                        Price = gPlatform.Price,
                        Stock = gPlatform.Stock
                    });
                }
            }


            return gameDTO;

        }

        public override Game Reverse(GameDTO item)
        {
            var game = new Game()
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                CoverUrl = item.CoverUrl,
                TrailerUrl = item.TrailerUrl,
                ReleaseDate = item.ReleaseDate

            };
            if (item.Genres != null)
            {
                game.Genres = new List<Genre>();
                foreach (var genreDTO in item.Genres)
                {
                    game.Genres.Add(new GenreConverter().Reverse(genreDTO));
                }
            }
            return game;
        }
    }
}
