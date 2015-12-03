using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class CrewGameSuggestionRepository : IRepository<CrewGameSuggestion>
    {
        private MVOGamesContext ctx;

        public CrewGameSuggestionRepository(MVOGamesContext context)
        {
            ctx = context;
        }

        public void Add(CrewGameSuggestion t)
        {
            ctx.CrewGameSuggestions.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
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

        public CrewGameSuggestion Find(int? id)
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

        public List<CrewGameSuggestion> ReadAll()
        {
            return ctx.CrewGameSuggestions.ToList();
        }

        public void Update(CrewGameSuggestion t)
        {
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
