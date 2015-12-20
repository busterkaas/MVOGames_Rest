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
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class CrewRepository : IRepository<Crew>
    {
        public void Add(Crew t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Crews.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
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
        }

        public Crew Find(int? id)
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

        public List<Crew> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.Crews.Include("Users.Role").ToList();
            }
        }

        public void Update(Crew t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                var originalCrew = ctx.Crews.Include(j => j.Users)
                .Single(j => j.Id == t.Id);

                // Update scalar/complex properties
                ctx.Entry(originalCrew).CurrentValues.SetValues(t);

                // Update reference
                if (t.Users != null)
                {
                    originalCrew.Users.Clear();
                    foreach (var user in t.Users)
                    {
                        originalCrew.Users.Add(ctx.Users.FirstOrDefault(x => x.Id == user.Id));
                    }
                }

                ctx.SaveChanges();
            }
        }
    }
}
