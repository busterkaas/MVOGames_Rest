﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

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
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Role Find(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Role> ReadAll()
        {
            return ctx.Roles.ToList();
        }

        public void Update(Role t)
        {
            throw new NotImplementedException();
        }
    }
}
