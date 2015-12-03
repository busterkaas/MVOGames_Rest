using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class GenreRepository : IRepository<Genre>
    {
        private MVOGamesContext ctx;
        public GenreRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Genre t)
        {
            ctx.Genres.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
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

        public Genre Find(int? id)
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

        public List<Genre> ReadAll()
        {
            return ctx.Genres.ToList();
        }

        public void Update(Genre t)
        {
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
