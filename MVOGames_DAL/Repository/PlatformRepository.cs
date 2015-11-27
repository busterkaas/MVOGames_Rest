﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class PlatformRepository : IRepository<Platform>
    {
        private MVOGamesContext ctx;
        public PlatformRepository(MVOGamesContext context)
        {
            ctx = context;
        }

        public List<Platform> ReadAll()
        {
            return ctx.Platforms.ToList();
        }

        public void Add(Platform t)
        {
            ctx.Platforms.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            Platform platform = Find(id);
            try
            {
                ctx.Platforms.Attach(platform);
                ctx.Platforms.Remove(platform);
                ctx.SaveChanges();
            }
            catch
            {
            }
        }

        public Platform Find(int? id)
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

        public void Update(Platform t)
        {
            foreach (var platformDB in ctx.Platforms.ToList())
            {
                if (t.Id == platformDB.Id)
                {
                    platformDB.Name = t.Name;
                    ctx.Platforms.Attach(platformDB);
                }
            }
        }
    }
}
