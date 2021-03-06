﻿using DomainModels.Models;
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOModels.Converter
{
    public class PlatformConverter : AbstractDTOConverter<Platform, PlatformDTO>
    {
        public override PlatformDTO Convert(Platform item)
        {
            var platformDTO = new PlatformDTO()
            {
                Id = item.Id,
                Name = item.Name
            };
           
            return platformDTO;
        }

        public override Platform Reverse(PlatformDTO item)
        {
            var platform = new Platform()
            {
                Id = item.Id,
                Name = item.Name
            };
            
            return platform;
        }
    }
}
