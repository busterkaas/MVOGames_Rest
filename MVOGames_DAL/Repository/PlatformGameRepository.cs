﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class PlatformGameRepository : IRepository<PlatformGame>
    {
        private MVOGamesContext ctx;
        public PlatformGameRepository(MVOGamesContext context)
        {
            ctx = context;
        }

        public void Add(PlatformGame t)
        {
            ctx.PlatformGames.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            PlatformGame platforgames = Find(id);

            ctx.PlatformGames.Attach(platforgames);
            ctx.PlatformGames.Remove(platforgames);
            ctx.SaveChanges();
        }

        public PlatformGame Find(int? id)
        {
            foreach (var item in ReadAll())
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<PlatformGame> ReadAll()
        {
            return ctx.PlatformGames.Include("Game").Include("Platform").ToList();
        }

        public void Update(PlatformGame t)
        {
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
