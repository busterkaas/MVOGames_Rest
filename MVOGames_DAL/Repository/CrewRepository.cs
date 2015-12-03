using System;
using System.Collections.Generic;
using System.Linq;
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
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
