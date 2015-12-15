using MVOGames_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVOGames_DAL.Context
{
    public class MVOGamesContextInitializer : DropCreateDatabaseAlways<MVOGamesContext>
    {
        protected override void Seed(MVOGamesContext context)
        {
            Platform platform = context.Platforms.Add(new Platform() { Id = 1, Name = "Playstation 4" });
            Platform platform1 = context.Platforms.Add(new Platform() { Id = 2, Name = "XBOX One" });
            Platform platform2 = context.Platforms.Add(new Platform() { Id = 3, Name = "PC" });

            Genre genre1 = context.Genres.Add(new Genre() { Id = 1, Name = "FPS" });
            Genre genre2 = context.Genres.Add(new Genre() { Id = 2, Name = "Action" });
            Genre genre3 = context.Genres.Add(new Genre() { Id = 3, Name = "Adventure" });

            Role role1 = context.Roles.Add(new Role() { Id = 1, RoleName = "admin" });
            Role role2 = context.Roles.Add(new Role() { Id = 2, RoleName = "user" });

            User user = new User
            {
                Id = 1,
                Username = "buster",
                City = "Esbjerg",
                Email = "bulle@gmail.com",
                FirstName = "Buster",
                LastName = "Jensen",
                HouseNr = "175 C, 2th",
                StreetName = "Ingemanns Allé",
                ZipCode = 6700,
                Crews = new List<Crew> { },
                Role = role1
            };
            user.SetPassword("buster");
            User user2 = new User
            {
                Id = 2,
                Username = "shane",
                City = "Oslo",
                Email = "shalle@gmail.com",
                FirstName = "Shane",
                LastName = "Jensen",
                HouseNr = "1",
                StreetName = "Olso Allé",
                ZipCode = 7070,
                Crews = new List<Crew> { },
                Role = role2
            };
            user2.SetPassword("shane");
            User user3 = new User
            {
                Id = 3,
                Username = "Mikki",
                City = "Flensburg",
                Email = "mille@gmail.com",
                FirstName = "Mike",
                LastName = "Jensen",
                HouseNr = "23",
                StreetName = "Flensburg Allé",
                ZipCode = 1232,
                Crews = new List<Crew> { },
                Role = role2
            };
            user3.SetPassword("Mikki");

            User user4 = new User
            {
                Id = 4,
                Username = "dennis",
                City = "Esbjerg",
                Email = "delle@gmail.com",
                FirstName = "Dennis",
                LastName = "Petersen",
                HouseNr = "108, 2th",
                StreetName = "Perker allé",
                ZipCode = 6700,
                Crews = new List<Crew> { },
                Role = role2
            };
            user4.SetPassword("dennis");



            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);

            Crew crew = context.Crews.Add(new Crew() { Id = 1, Name = "SOB", CrewImgUrl = "http://prod.cloud.rockstargames.com/crews/sc/1510/10088/publish/emblem/emblem_128.png", Users = new List<User>() { user2, user3 }, CrewLeaderId = 2});

            IList<Game> games = new List<Game>();

            games.Add(new Game
            {
                Title = "GTA V",
                ReleaseDate = new DateTime(2014, 09, 28),
                //Price = 150,
                CoverUrl = "http://media.rockstargames.com/rockstargames/img/global/news/upload/actual_1364906194.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre2 },
                Description = "Go crazy ín los santos!! The city of oppotunities.",
            });
            games.Add(new Game
            {
                Title = "Rainbow Six - Siege",
                ReleaseDate = new DateTime(2015, 01, 28),
                //Price = 150,
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/4/47/Tom_Clancy%27s_Rainbow_Six_Siege_cover_art.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre2, genre1 },
                Description = "Become an terrorist or fight the terrorrists in this new and exiting FPS game.",
            });
            foreach (Game g in games)
            {
                context.Games.Add(g);

            }

            PlatformGame pg =
                context.PlatformGames.Add(new PlatformGame() { Id = 1, GameId = 1, PlatformId = 1, Price = 499, Stock = 20 });
            PlatformGame pg1 =
                context.PlatformGames.Add(new PlatformGame() { Id = 2, GameId = 1, PlatformId = 2, Price = 469, Stock = 15 });
            PlatformGame pg2 =
              context.PlatformGames.Add(new PlatformGame() { Id = 3, GameId = 1, PlatformId = 3, Price = 400, Stock = 0 });
            PlatformGame pg3 =
                context.PlatformGames.Add(new PlatformGame() { Id = 4, GameId = 2, PlatformId = 1, Price = 549, Stock = 15 });
            PlatformGame pg4 =
              context.PlatformGames.Add(new PlatformGame() { Id = 5, GameId = 2, PlatformId = 2, Price = 529, Stock = 0 });


            //Order o = context.Orders.Add(new Order() { Id = 1, Date = DateTime.Today, UserId = 1 });
            //Order o1 = context.Orders.Add(new Order() { Id = 2, Date = DateTime.Today, UserId = 1 });
            //Order o2 = context.Orders.Add(new Order() { Id = 3, Date = DateTime.Today, UserId = 3 });
            //Order o3 = context.Orders.Add(new Order() { Id = 4, Date = DateTime.Today, UserId = 2 });
            //Order o4 = context.Orders.Add(new Order() { Id = 5, Date = DateTime.Today, UserId = 3 });

            //Orderline ol = context.Orderlines.Add(new Orderline() { Amount = 1, Discount = 0, PlatformGameId = 1, OrderId = 1 });
            //Orderline ol1 = context.Orderlines.Add(new Orderline() { Amount = 2, Discount = 0, PlatformGameId = 2, OrderId = 1 });
            //Orderline ol2 = context.Orderlines.Add(new Orderline() { Amount = 1, Discount = 0, PlatformGameId = 3, OrderId = 1 });
            //Orderline ol3 = context.Orderlines.Add(new Orderline() { Amount = 5, Discount = 2, PlatformGameId = 2, OrderId = 2 });
            //Orderline ol4 = context.Orderlines.Add(new Orderline() { Amount = 2, Discount = 0, PlatformGameId = 4, OrderId = 3 });
            //Orderline ol5 = context.Orderlines.Add(new Orderline() { Amount = 1, Discount = 0, PlatformGameId = 1, OrderId = 4 });
            //Orderline ol6 = context.Orderlines.Add(new Orderline() { Amount = 1, Discount = 0, PlatformGameId = 3, OrderId = 5 });
            base.Seed(context);


        }
    }
}
