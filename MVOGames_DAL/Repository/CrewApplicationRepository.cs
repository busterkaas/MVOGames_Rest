﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    class CrewApplicationRepository : IRepository<CrewApplication>
    {
        private MVOGamesContext ctx;
        public CrewApplicationRepository(MVOGamesContext context)
        {
            ctx = context;
        }
        public void Add(CrewApplication t)
        {
            ctx.CrewApplications.Add(t);
            ctx.SaveChanges();
        }

        public void Delete(int? id)
        {
            CrewApplication crewApplication = Find(id);
            try
            {
                ctx.CrewApplications.Attach(crewApplication);
                ctx.CrewApplications.Remove(crewApplication);
                ctx.SaveChanges();
            }
            catch
            {
            }
        }

        public CrewApplication Find(int? id)
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

        public List<CrewApplication> ReadAll()
        {
            return ctx.CrewApplications.ToList();
        }

        public void Update(CrewApplication t)
        {
            foreach (var crewApplicationDB in ctx.CrewApplications.ToList())
            {
                if (t.Id == crewApplicationDB.Id)
                {

                    crewApplicationDB.CrewId = t.CrewId;
                    crewApplicationDB.UserId = t.UserId;
                    ctx.CrewApplications.Attach(crewApplicationDB);
                }
            }
        }
    }
}