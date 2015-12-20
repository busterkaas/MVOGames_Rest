using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using DomainModels.Models;

namespace MVOGames_DAL.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        public void Add(Role t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                ctx.Roles.Add(t);
                ctx.SaveChanges();
            }
        }

        public void Delete(int? id)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                Role role = Find(id);
                try
                {
                    ctx.Roles.Attach(role);
                    ctx.Roles.Remove(role);
                    ctx.SaveChanges();
                }
                catch
                {
                }
            }
        }

        public Role Find(int? id)
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

        public List<Role> ReadAll()
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                return ctx.Roles.ToList();
            }
        }

        public void Update(Role t)
        {
            using (MVOGamesContext ctx = new MVOGamesContext())
            {
                foreach (var rolesDB in ctx.Roles.ToList())
                {
                    if (t.Id == rolesDB.Id)
                    {
                        rolesDB.RoleName = t.RoleName;
                        ctx.Roles.Attach(rolesDB);
                    }
                }
            }
        }
    }
}
