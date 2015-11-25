using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;

namespace MVOGames_DAL.Repository
{
    public class PlatformRepository : IRepository<Platform>
    {
        private MVOGamesContext ctx;
        public PlatformRepository(MVOGamesContext context)
        {
            ctx = context;
        }

        public List<Platform> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Platform t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public Platform Find(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(Platform t)
        {
            throw new NotImplementedException();
        }
    }
}
