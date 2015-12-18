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
        private MVOGamesContext ctx;
        public RoleRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(Role t)
        {
            ctx.Roles.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
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

        public Role Find(int? id)
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

        public List<Role> ReadAll()
        {
            return ctx.Roles.ToList();
        }

        public void Update(Role t)
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
