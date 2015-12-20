using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class PlatformRepository : IRepository<Platform>
    {

        public List<Platform> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.Platforms.ToList();
            }
        }

        public void Add(Platform t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Platforms.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
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
        }

        public Platform Find(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
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
        }

        public void Update(Platform t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
