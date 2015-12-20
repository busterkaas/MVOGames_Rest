using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class UserRepository : IRepository<User>
    {
        public void Add(User t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Users.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                User user = Find(id);
                try
                {
                    ctx.Users.Attach(user);
                    ctx.Users.Remove(user);
                    ctx.SaveChanges();
                }
                catch (SqlException)
                {

                }
            }
        }

        public User Find(int? id)
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

        public User FindByUsername(string username)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
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
        }

        public List<User> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.Users.Include("Crews").Include("Role").ToList();
            }
        }

        public void Update(User t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Entry(t).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
        }

       
    }
}
