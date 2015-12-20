using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class PlatformGameRepository : IRepository<PlatformGame>
    {
        public void Add(PlatformGame t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.PlatformGames.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                PlatformGame platforgames = Find(id);

                ctx.PlatformGames.Attach(platforgames);
                ctx.PlatformGames.Remove(platforgames);
                ctx.SaveChanges();
            }
        }

        public PlatformGame Find(int? id)
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

        public List<PlatformGame> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.PlatformGames.Include("Game").Include("Platform").ToList();
            }
        }

        public void Update(PlatformGame t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
