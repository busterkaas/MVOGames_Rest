using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        private MVOGamesContext ctx;
        public UserRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(User t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public User Find(int? id)
        {
            throw new NotImplementedException();
        }

        public User FindByUsername(string username)
        {
            var user = ctx.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }

        public List<User> ReadAll()
        {
            return ctx.Users.Include("Crews").ToList();
        }

        public void Update(User t)
        {
            throw new NotImplementedException();
        }
    }
}
