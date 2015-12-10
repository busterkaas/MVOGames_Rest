using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MVOGames_DAL.Repository
{
    public class GameRepository : IRepository<Game>
    {
        private MVOGamesContext ctx;
        public GameRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Game t)
        {
            if (t.Genres != null)
            {
                t.Genres.ForEach(x => ctx.Entry(x).State = EntityState.Unchanged);
                ctx.Games.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
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

        public Game Find(int? id)
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

        public List<Game> ReadAll()
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

        public void Update(Game t)
        {
            ctx.Entry(t).State = EntityState.Modified;

            foreach (var item in t.Genres)
            {
                ctx.Entry(item).State = EntityState.Modified;

            }
            ctx.SaveChanges();
        }


        //public void UpdateOrderGame(Game t, List<Genre> genre)
        //{
        //    ctx.Entry(t).State = EntityState.Modified;
        //    foreach (Genre g in genre)
        //    {
        //        ctx.Entry(g).State = EntityState.Modified;
        //    }
        //    ctx.SaveChanges();
        //}
    }
}
