using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVOGames_DAL.Context;
using MVOGames_DAL.Repository;
using DomainModels.Models;

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
        private IRepository<PlatformGame> platformGameRepo;
        private IRepository<CrewGameSuggestion> CGSRepo;
        private IRepository<Order> OrderRepo;
        private IRepository<Orderline> OrderlineRepo;
        private IRepository<SuggestionUsers> SuggestionUsersRepo;

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
        public IRepository<PlatformGame> GetPlatformGameRepository()
        {
            return platformGameRepo ?? (platformGameRepo = new PlatformGameRepository(ctx));
        }
        public IRepository<CrewGameSuggestion> GetCGSRepository()
        {
            return CGSRepo ?? (CGSRepo = new CrewGameSuggestionRepository(ctx));
        }
        public IRepository<Order> GetOrderRepository()
        {
            return OrderRepo ?? (OrderRepo = new OrderRepository(ctx));
        }
        public IRepository<Orderline> GetOrderlineRepository()
        {
            return OrderlineRepo ?? (OrderlineRepo = new OrderlinesRepository(ctx));
        }
        public IRepository<SuggestionUsers> GetSuggestionUsersRepository()
        {
            return SuggestionUsersRepo ?? (SuggestionUsersRepo = new SuggestionUsersRepository(ctx));
        }
    }
}
