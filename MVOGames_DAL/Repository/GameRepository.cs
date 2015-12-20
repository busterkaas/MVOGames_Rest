using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class GameRepository : IRepository<Game>
    {
        public void Add(Game t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                if (t.Genres != null)
                {
                    t.Genres.ForEach(x => ctx.Entry(x).State = EntityState.Unchanged);
                    ctx.Games.Add(t);
                    ctx.SaveChanges();
                }
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                Game game = Find(id);
                try
                {
                    ctx.Games.Attach(game);
                    ctx.Games.Remove(game);
                    ctx.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {

                }
            }
        }

        public Game Find(int? id)
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

        public List<Game> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                try
                {
                    return ctx.Games.Include("Genres").ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public void Update(Game t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                var original = ctx.Games.Include(j => j.Genres)
               .Single(j => j.Id == t.Id);

                // Update scalar/complex properties
                ctx.Entry(original).CurrentValues.SetValues(t);

                // Update reference
                original.Genres.Clear();

                foreach (var genre in t.Genres)
                {
                    //ctx.Users.Attach(user);
                    original.Genres.Add(ctx.Genres.FirstOrDefault(x => x.Id == genre.Id));

                    //ctx.Entry(t).State = EntityState.Modified;

                    //foreach (var item in t.Genres)
                    //{
                    //    ctx.Entry(item).State = EntityState.Modified;
                    //}
                }
                ctx.SaveChanges();
            }
        }
    }
}
