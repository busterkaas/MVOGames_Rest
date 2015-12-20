using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    class CrewApplicationRepository : IRepository<CrewApplication>
    {
        public void Add(CrewApplication t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                t.User = new User() { Id = t.UserId };
                t.Crew = new Crew() { Id = t.CrewId };
                ctx.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                ctx.CrewApplications.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                CrewApplication crewApplication = Find(id);
                try
                {
                    ctx.CrewApplications.Attach(crewApplication);
                    ctx.CrewApplications.Remove(crewApplication);
                    ctx.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public CrewApplication Find(int? id)
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

        public List<CrewApplication> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.CrewApplications.Include("User").ToList();
            }
        }

        public void Update(CrewApplication t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
