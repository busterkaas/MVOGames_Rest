using MVOGames_DAL.Context;
using MVOGames_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Repository
{
    public class SuggestionUsersRepository : IRepository<SuggestionUsers>
    {
        private MVOGamesContext ctx;
        public SuggestionUsersRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(SuggestionUsers t)
        {
            ctx.SuggestionUsers.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
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

        public SuggestionUsers Find(int? id)
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

        public List<SuggestionUsers> ReadAll()
        {
            return ctx.SuggestionUsers.ToList();
        }

        public void Update(SuggestionUsers t)
        {
            ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }
    }
}
