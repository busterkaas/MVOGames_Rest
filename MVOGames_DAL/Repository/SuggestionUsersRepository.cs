using DomainModels.Models;
using MVOGames_DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Repository
{
    public class SuggestionUsersRepository : IRepository<SuggestionUsers>
    {
        public void Add(SuggestionUsers t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                t.User = new User() { Id = t.UserId };
                t.CrewGameSuggestion = new CrewGameSuggestion() { Id = t.CrewGameSuggestionId };
                ctx.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                ctx.SuggestionUsers.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                SuggestionUsers suggestionUsers = Find(id);
                try
                {
                    ctx.SuggestionUsers.Attach(suggestionUsers);
                    ctx.SuggestionUsers.Remove(suggestionUsers);
                    ctx.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public SuggestionUsers Find(int? id)
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

        public List<SuggestionUsers> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.SuggestionUsers.Include("User.Crews").Include("User.Role").Include("CrewGameSuggestion.PlatformGame.Game").Include("CrewGameSuggestion.PlatformGame.Platform").ToList();
            }
        }

        public void Update(SuggestionUsers t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }
    }
}
