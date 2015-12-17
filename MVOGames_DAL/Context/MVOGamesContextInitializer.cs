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
            Genre genre4 = context.Genres.Add(new Genre() { Id = 3, Name = "RTS" });
            Genre genre5 = context.Genres.Add(new Genre() { Id = 3, Name = "MMO" });
            Genre genre6 = context.Genres.Add(new Genre() { Id = 3, Name = "RPG" });
            Genre genre7 = context.Genres.Add(new Genre() { Id = 3, Name = "Sport" });
            Genre genre8 = context.Genres.Add(new Genre() { Id = 3, Name = "Horror" });
            Genre genre9 = context.Genres.Add(new Genre() { Id = 3, Name = "Racing" });
            


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
                StreetName = "GettoNettoGade",
                ZipCode = 6700,
                Crews = new List<Crew> { },
                Role = role2
            };
            user4.SetPassword("dennis");

            User user5 = new User
            {
                Id = 5,
                Username = "kensie",
                City = "Esbjerg",
                Email = "kelle@gmail.com",
                FirstName = "Kennie",
                LastName = "Ankersøe",
                HouseNr = "2",
                StreetName = "Ølgade",
                ZipCode = 6700,
                Crews = new List<Crew> { },
                Role = role2
            };
            user5.SetPassword("kensie");
            User user6 = new User
            {
                Id = 6,
                Username = "tasina",
                City = "Esbjerg",
                Email = "tas@gmail.com",
                FirstName = "Tasin",
                LastName = "Akdeniz",
                HouseNr = "12, 10tv",
                StreetName = "Jotlevej",
                ZipCode = 6700,
                Crews = new List<Crew> { },
                Role = role2
            };
            user6.SetPassword("tasina");
            User user7 = new User
            {
                Id = 7,
                Username = "Baasteeringz",
                City = "Esbjerg",
                Email = "bulle@gmail.com",
                FirstName = "Buster",
                LastName = "Jensen",
                HouseNr = "175 C, 2th",
                StreetName = "Ingemanns Allé",
                ZipCode = 6700,
                Crews = new List<Crew> { },
                Role = role2
            };
            user7.SetPassword("buster");
            User user8 = new User
            {
                Id = 8,
                Username = "user",
                City = "UserCity",
                Email = "user@user.com",
                FirstName = "User",
                LastName = "Userness",
                HouseNr = "1",
                StreetName = "UserStreet",
                ZipCode = 1000,
                Crews = new List<Crew> { },
                Role = role2
            };
            user8.SetPassword("user");



            context.Users.Add(user);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.Users.Add(user4);
            context.Users.Add(user5);
            context.Users.Add(user6);
            context.Users.Add(user7);
            context.Users.Add(user8);

            Crew crew = context.Crews.Add(new Crew() { Id = 1, Name = "SOB", CrewImgUrl = "http://prod.cloud.rockstargames.com/crews/sc/1510/10088/publish/emblem/emblem_128.png", Users = new List<User>() { user2, user3, user7 }, CrewLeaderId = 2});
            Crew crew2 = context.Crews.Add(new Crew() { Id = 1, Name = "PS4Crew", CrewImgUrl = "", Users = new List<User>() { user7, user3, user2 }, CrewLeaderId = 6 });
            Crew crew3 = context.Crews.Add(new Crew() { Id = 1, Name = "NoNamesCrew", CrewImgUrl = "", Users = new List<User>() { user6 }, CrewLeaderId = 5 });
            Crew crew1 = context.Crews.Add(new Crew() { Id = 1, Name = "Esbjerg Homies", CrewImgUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/4/4e/Columbus_Crew_logo_(1996%E2%80%932014).svg/849px-Columbus_Crew_logo_(1996%E2%80%932014).svg.png", Users = new List<User>() { user7, user6, user5, user4 }, CrewLeaderId = 6 });
            Crew crew4 = context.Crews.Add(new Crew() { Id = 1, Name = "LoL", CrewImgUrl = "", Users = new List<User>() { user5  }, CrewLeaderId = 4 });
            Crew crew5 = context.Crews.Add(new Crew() { Id = 1, Name = "Peters gruppe", CrewImgUrl = "", Users = new List<User>() { user8, user4 }, CrewLeaderId = 7 });
            Crew crew6 = context.Crews.Add(new Crew() { Id = 1, Name = "Gangsta crew", CrewImgUrl = "", Users = new List<User>() { user8, user5 }, CrewLeaderId = 7 });
            Crew crew7 = context.Crews.Add(new Crew() { Id = 1, Name = "uAndMeTogether", CrewImgUrl = "", Users = new List<User>() { user8 }, CrewLeaderId = 7 });
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
            games.Add(new Game
            {
                Title = "Battlefield 4",
                ReleaseDate = new DateTime(2014, 08, 08),
                //Price = 150,
                CoverUrl = "http://static.europosters.cz/image/750/plakater/battlefield-4-cover-i14536.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre2, genre1 },
                Description = "Be a soldier and compete against your opponents in this realistic war game",
            });
            games.Add(new Game
            {
                Title = "Overwatch",
                ReleaseDate = new DateTime(2015, 12, 14),
                //Price = 150,
                CoverUrl = "http://img.game.co.uk/ml2/3/4/2/3/342368_pcw_b.png",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre1, genre3 },
                Description = "Watcha' lookin' at?",
            });
            games.Add(new Game
            {
                Title = "Diablo III: Reaper of Souls",
                ReleaseDate = new DateTime(2014, 03, 25),
                //Price = 150,
                CoverUrl = "https://gbatemp.net/data/reviews/boxart/full/132.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre2, genre6 },
                Description = "Defeat Malphael as the Nephalim champion. lol",
            });
            games.Add(new Game
            {
                Title = "Need for Speed",
                ReleaseDate = new DateTime(2015, 10, 10),
                //Price = 150,
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/a/a9/Need_for_Speed_2015.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre9 },
                Description = "The latest game in the popular Need for Speed series",
            });
            games.Add(new Game
            {
                Title = "Forza Horizon 2",
                ReleaseDate = new DateTime(2015, 04, 11),
                //Price = 150,
                CoverUrl = "http://images.8tracks.com/avatar/i/004/735/698/63291.original-8254.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre9 },
                Description = "Play this amazing XboxOne exclusive racing game.",
            });
            games.Add(new Game
            {
                Title = "Bloodborne: The Old Hunters",
                ReleaseDate = new DateTime(2015, 11, 7),
                //Price = 150,
                CoverUrl = "https://cdn1.vox-cdn.com/thumbor/FNYxHtdtswoDPnsMEp2Geac8or8=/cdn0.vox-cdn.com/uploads/chorus_asset/file/4062346/BB-The-Old-Hunters_Key-Art.0.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre8 },
                Description = "Be afraid. Be very afraid",
            });
            games.Add(new Game
            {
                Title = "The Witcher III: Wild Hunt",
                ReleaseDate = new DateTime(2015, 05, 19),
                //Price = 150,
                CoverUrl = "http://gamerzblock.com/file/2015/10/the-witcher-3-wild-hunt-cover-250x274.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre2, genre6 },
                Description = "Follow the adventures of Geralt of Rivia in the action packed game of the year.",
            });
            games.Add(new Game
            {
                Title = "Fallout 4",
                ReleaseDate = new DateTime(2015, 11, 1),
                //Price = 150,
                CoverUrl = "https://cdn0.vox-cdn.com/thumbor/x1mQOB4hlVoVDZyKMWlXWNbL08I=/cdn0.vox-cdn.com/uploads/chorus_asset/file/3986836/AOFALLOUT4_CVR_SOL.0.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre1, genre6 },
                Description = "Explore the post apocalypic price winning world of Bethesda",
            });
            games.Add(new Game
            {
                Title = "World of Warcraft: Legion",
                ReleaseDate = new DateTime(2015, 11, 16),
                //Price = 150,
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/2/22/Legion_cover.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre5, genre6 },
                Description = "Save Azeroth from the Burning Legion in the latest WoW Expansion!",
            });
            games.Add(new Game
            {
                Title = "Rocket League",
                ReleaseDate = new DateTime(2014, 09, 28),
                //Price = 150,
                CoverUrl = "http://www.mobygames.com/images/covers/l/307552-rocket-league-playstation-4-front-cover.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre9, genre7 },
                Description = "Test your skills in this amazing football racing mashup!",
            });
            games.Add(new Game
            {
                Title = "Starcraft II: Legacy of the Void",
                ReleaseDate = new DateTime(2015, 11, 28),
                //Price = 150,
                CoverUrl = "http://mms.businesswire.com/media/20141107005107/en/440211/5/SCII_Legacy_of_the_Void_Key_Art_01_with_Logo%5B1%5D.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre4 },
                Description = "Best RTS game in the world!",
            });
            games.Add(new Game
            {
                Title = "Warcraft III",
                ReleaseDate = new DateTime(2002, 11, 28),
                //Price = 150,
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/6/66/WarcraftIII.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre4 },
                Description = "Bestest RTS game in the world!",
            });
            games.Add(new Game
            {
                Title = "Fifa 16",
                ReleaseDate = new DateTime(2015, 09, 22),
                //Price = 150,
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/2/27/FIFA_16_cover.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre7 },
                Description = "If you can't find anything else to do, play the newest version of the Fifa Franchise",
            });
            games.Add(new Game
            {
                Title = "Last of Us",
                ReleaseDate = new DateTime(2013, 06, 14),
                //Price = 150,
                CoverUrl = "https://upload.wikimedia.org/wikipedia/en/4/46/Video_Game_Cover_-_The_Last_of_Us.jpg",
                TrailerUrl = "https://www.youtube.com/embed/JOddp-nlNvQ",

                Genres = new List<Genre>() { genre8, genre3 },
                Description = "Play through this tearfilled, action packed masterpiece",
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

            
            context.PlatformGames.Add(new PlatformGame() { GameId = 2, PlatformId = 2, Price = 529, Stock = 0 });
            PlatformGame pg5 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 3, PlatformId = 1, Price = 400, Stock = 30 });
            PlatformGame pg6 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 3, PlatformId = 2, Price = 400, Stock = 20 });
            PlatformGame pg7 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 3, PlatformId = 3, Price = 300, Stock = 11 });
            PlatformGame pg8 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 4, PlatformId = 1, Price = 350, Stock = 0 });
            PlatformGame pg9 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 4, PlatformId = 2, Price = 360, Stock = 0 });
            PlatformGame pg10 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 4, PlatformId = 3, Price = 300, Stock = 1 });
            PlatformGame pg11 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 5, PlatformId = 3, Price = 200, Stock = 12 });
            PlatformGame pg12 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 6, PlatformId = 1, Price = 499, Stock = 23 });
            PlatformGame pg13 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 6, PlatformId = 2, Price = 509, Stock = 34 });
            PlatformGame pg14 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 6, PlatformId = 3, Price = 449, Stock = 7 });
            PlatformGame pg15 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 7, PlatformId = 2, Price = 499, Stock = 18 });
            PlatformGame pg16 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 8, PlatformId = 1, Price = 429, Stock = 40 });
            PlatformGame pg17 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 9, PlatformId = 1, Price = 524, Stock = 10 });
            PlatformGame pg18 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 9, PlatformId = 2, Price = 500, Stock = 12 });
            PlatformGame pg19 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 9, PlatformId = 3, Price = 419, Stock = 15 });
            PlatformGame pg20 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 10, PlatformId = 1, Price = 529, Stock = 0 });
            PlatformGame pg21 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 10, PlatformId = 2, Price = 539, Stock = 2 });
            PlatformGame pg22 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 10, PlatformId = 3, Price = 450, Stock = 9 });
            PlatformGame pg23 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 11, PlatformId = 3, Price = 449, Stock = 11 });
            PlatformGame pg24 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 12, PlatformId = 1, Price = 150, Stock = 19 });
            PlatformGame pg25 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 12, PlatformId = 2, Price = 150, Stock = 12 });
            PlatformGame pg26 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 12, PlatformId = 3, Price = 75, Stock = 21 });
            PlatformGame pg27 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 13, PlatformId = 3, Price = 429, Stock = 34 });
            PlatformGame pg28 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 14, PlatformId = 3, Price = 50, Stock = 34 });
            PlatformGame pg29 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 15, PlatformId = 1, Price = 429, Stock = 20 });
            PlatformGame pg30 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 15, PlatformId = 2, Price = 429, Stock = 4 });
            PlatformGame pg31 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 15, PlatformId = 3, Price = 339, Stock = 22 });
            PlatformGame pg32 =
              context.PlatformGames.Add(new PlatformGame() { GameId = 16, PlatformId = 1, Price = 429, Stock = 34 });
            
            base.Seed(context);


        }
    }
}
