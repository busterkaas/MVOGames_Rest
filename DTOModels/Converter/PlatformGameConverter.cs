﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOModels.Models;
using MVOGames_DAL.Models;

namespace DTOModels.Converter
{
    class PlatformGameConverter : AbstractDTOConverter<PlatformGame, PlatformGameDTO>
    {
        public override PlatformGameDTO Convert(PlatformGame item)
        {
            var platformGameDTO = new PlatformGameDTO()
            {
                GameId = item.GameId,
                PlatformId = item.PlatformId,
                Game = new GameConverter().Convert(item.Game),
                Platform = new PlatformConverter().Convert(item.Platform),
                Price = item.Price,
                Stock = item.Stock
            };
            return platformGameDTO;
        }

        public override PlatformGame Reverse(PlatformGameDTO item)
        {
            var platformGame = new PlatformGame()
            {
                GameId = item.GameId,
                PlatformId = item.PlatformId,
                Game = new GameConverter().Reverse(item.Game),
                Platform = new PlatformConverter().Reverse(item.Platform),
                Price = item.Price,
                Stock = item.Stock
            };
            return platformGame;
        }
    }
}
