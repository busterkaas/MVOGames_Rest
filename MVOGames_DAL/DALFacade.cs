using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Models;
using MVOGames_DAL.Repository;

namespace MVOGames_DAL
{
    public class DALFacade
    {
        private MVOGamesContext ctx;
        private IRepository<Game> gameRepo;
        private IRepository<Genre> genreRepo;
        private IRepository<Crew> crewRepo;
        private UserRepository userRepo;
        private IRepository<Role> roleRepo;
        private IRepository<Platform> platformRepo;
        private IRepository<CrewApplication> crewApplicationRepo; 

        public DALFacade()
        {
            ctx = new MVOGamesContext();
        }

        public IRepository<Game> GetGameRepository()
        {
            return gameRepo ?? (gameRepo = new GameRepository(ctx));
        }
        public IRepository<Genre> GetGenreRepository()
        {
            return genreRepo ?? (genreRepo = new GenreRepository(ctx));
        }
        public IRepository<Crew> GetCrewRepository()
        {
            return crewRepo ?? (crewRepo = new CrewRepository(ctx));
        }
        public UserRepository GetUserRepository()
        {
            return userRepo ?? (userRepo = new UserRepository(ctx));
        }
        public IRepository<Role> GetRoleRepository()
        {
            return roleRepo ?? (roleRepo = new RoleRepository(ctx));
        }
        public IRepository<Platform> GetPlatformRepository()
        {
            return platformRepo ?? (platformRepo = new PlatformRepository(ctx));
        }
        public IRepository<CrewApplication> GetCrewApplicationRepository()
        {
            return crewApplicationRepo ?? (crewApplicationRepo = new CrewApplicationRepository(ctx));
        }
    }
}
