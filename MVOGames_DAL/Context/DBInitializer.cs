﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Context
{
    public static class DBInitializer
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MVOGamesContextInitializer());
        }
    }
}
