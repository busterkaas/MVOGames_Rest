using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class CrewGameSuggestionRepository : IRepository<CrewGameSuggestion>
    {

        public void Add(CrewGameSuggestion t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                t.Crew = new Crew() { Id = t.CrewId };
                t.PlatformGame = new PlatformGame() { Id = t.PlatformGameId };
                ctx.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                ctx.CrewGameSuggestions.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                CrewGameSuggestion crewGameSuggestion = Find(id);
                try
                {
                    ctx.CrewGameSuggestions.Attach(crewGameSuggestion);
                    ctx.CrewGameSuggestions.Remove(crewGameSuggestion);
                    ctx.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public CrewGameSuggestion Find(int? id)
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

        public List<CrewGameSuggestion> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.CrewGameSuggestions.Include("Crew").Include("PlatformGame.Game").Include("PlatformGame.Platform").ToList();
            }
        }

        public void Update(CrewGameSuggestion t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
