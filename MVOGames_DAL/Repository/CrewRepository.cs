using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class CrewRepository : IRepository<Crew>
    {
        private MVOGamesContext ctx;
        public CrewRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Crew t)
        {
            ctx.Crews.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            Crew crew = Find(id);
            try
            {
                ctx.Crews.Attach(crew);
                ctx.Crews.Remove(crew);
                ctx.SaveChanges();
            }
            catch
            {
            }
        }

        public Crew Find(int? id)
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

        public List<Crew> ReadAll()
        {
            return ctx.Crews.ToList();
        }

        public void Update(Crew t)
        {
            var originalCrew = ctx.Crews.Include(j => j.Users)
                .Single(j => j.Id == t.Id);

            // Update scalar/complex properties
            ctx.Entry(originalCrew).CurrentValues.SetValues(t);

            // Update reference
            originalCrew.Users.Clear();
           
            foreach (var user in t.Users)
            {
                //ctx.Users.Attach(user);
                originalCrew.Users.Add(ctx.Users.FirstOrDefault(x => x.Id == user.Id));
                

        }

            //db.Genres.Attach(entity.Genre)
            //originalVinyl.Genre = entity.Genre;

            ctx.SaveChanges();
        }
    }
}
