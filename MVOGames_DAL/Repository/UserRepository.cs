using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            ctx.Users.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            User user = Find(id);
            try
            {
                ctx.Users.Attach(user);
                ctx.Users.Remove(user);
                ctx.SaveChanges();
            }
            catch(SqlException e)
            {

            }
        }

        public User Find(int? id)
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
            return ctx.Users.Include("Crews").Include("Role").ToList();
        }

        public void Update(User t)
        {
            foreach (var userDB in ctx.Users.ToList())
            {
                if (t.Id == userDB.Id)
                {
                    userDB.Username = t.Username;
                    userDB.FirstName = t.FirstName;
                    userDB.LastName = t.LastName;
                    userDB.StreetName = t.StreetName;
                    userDB.HouseNr = t.HouseNr;
                    userDB.ZipCode = t.ZipCode;
                    userDB.City = t.City;
                    userDB.Email = t.Email;
                    userDB.PasswordHash = t.PasswordHash;
                    ctx.Users.Attach(userDB);
                }
            }
        }
    }
}
