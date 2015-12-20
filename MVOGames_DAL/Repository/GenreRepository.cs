using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        public void Add(Genre t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Genres.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                Genre genre = Find(id);
                try
                {
                    ctx.Genres.Attach(genre);
                    ctx.Genres.Remove(genre);
                    ctx.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public Genre Find(int? id)
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

        public List<Genre> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.Genres.ToList();
            }
        }

        public void Update(Genre t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
