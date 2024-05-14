using LibGit2Sharp;
using Moq;
using NuGet.ContentModel;
using NUnit.Framework;
using PDDGB7_HFT_2023242.Logic.Classes;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace PDDGB7_HFT_2023242.Test
{
    public class Tester
    {
        [TestFixture]
        public class Tests
        {
            Mock<IRepository<Game>> mockGameRepo;
            GameLogic gamelogic;
            Mock<IRepository<RentLog>> mockRentLogRepo;
            RentLogLogic rentlogLogic;
            Mock<IRepository<User>> mockUserRepo;
            UserLogic userLogic;

            [SetUp]
            public void Init()
            {
                List<Developer> developers = new List<Developer>()
                {
                   new Developer("1#Gearbox Software"),
                new Developer("2#Blizzard"),
                
                };
                List<Game> games = new List<Game>
                {
                    new Game("1#1#Borderlands#2009*10*20"){Developer=developers[0]},
                new Game("2#1#Borderlands 2#2012*09*18"){Developer=developers[0]},
                new Game("3#1#Borderlands 3#2019*09*13"){Developer=developers[0]},
                new Game("4#2#Diablo 2#2000*06*28"){Developer=developers[1]},
                new Game("5#2#Diablo 3#2012*05*15"){Developer=developers[1]},
                };
                List<RentLog> rentLogs = new List<RentLog>()
                {
                     new RentLog("1#1#1#2023*05*23") {Game=games[0]},
                new RentLog("2#2#2#2023*05*23"){Game=games[1] },
                new RentLog("3#3#2#2023*05*27"){Game=games[1]},
                new RentLog("4#4#4#2024*01*10"){Game=games[3]},
                new RentLog("5#5#5#2024*02*11"){Game=games[4]},
              
                };
                List<User> users = new List<User>()
                {
                    new User("1#Vasas Lajos#ABC12"){RentLogs=new List<RentLog>(){rentLogs[0] } },
                new User("2#Deák Imre#ASD51"){RentLogs=new List<RentLog>(){rentLogs[1] } },
                new User("3#Kis Norbert#LKJ65"){RentLogs=new List<RentLog>(){rentLogs[2] } },
                new User("4#Nagy Balázs#583JT"){RentLogs=new List<RentLog>(){rentLogs[3] } },
                new User("5#Lakatos Arnold#LFG66"){RentLogs=new List<RentLog>(){rentLogs[4] } },
                };

                mockUserRepo = new Mock<IRepository<User>>();
                mockUserRepo.Setup(m => m.ReadAll()).Returns(users.AsQueryable());
                mockUserRepo.Setup(m => m.Read(It.IsAny<int>())).Returns<int>(a => mockUserRepo.Object.ReadAll().FirstOrDefault(t => t.Id == a));
                userLogic = new UserLogic(mockUserRepo.Object);

                mockGameRepo = new Mock<IRepository<Game>>();
                mockGameRepo.Setup(m => m.ReadAll()).Returns(games.AsQueryable());
                gamelogic = new GameLogic(mockGameRepo.Object);

                mockRentLogRepo = new Mock<IRepository<RentLog>>();
                mockRentLogRepo.Setup(m => m.ReadAll()).Returns(rentLogs.AsQueryable());
                rentlogLogic = new RentLogLogic(mockRentLogRepo.Object);

            }
            [Test]
            public void MostPlayedGameTest()
            {
                Assert.That(rentlogLogic.MostPlayedGame() == "Borderlands 2");
            }
            [Test]
            public void RentsOnDateTest()
            {
                Assert.That(rentlogLogic.NumberOfDevelopersGamesRentedAtDate("Gearbox Software", System.DateTime.Parse("2023.05.23")) == 2);
            }
            [Test]
            public void GetAllUsersAverageNumberOfRentsTest()
            {
                Assert.That(userLogic.GetAllUsersAverageNumberOfRents() == (double)5 / 5);
            }
            [Test]
            public void NumberOfGamesByDeveloperTest()
            {
                Assert.That(gamelogic.NumberOfGamesByDeveloper("Gearbox Software") == 3);
            }
            [Test]
            public void CreateGameTestWithCorrectTitle()
            {
                var game = new Game("1#1#Coolest Game Ever#2024*05*14");
                gamelogic.Create(game);
                mockGameRepo.Verify(r => r.Create(game), Times.Once);
                Assert.Pass();
            }
            [Test]
            public void CreateGameTestWithInCorrectTitle()
            {
                var game = new Game("1#1##2007*08*10");
                try
                {
                    gamelogic.Create(game);
                }
                catch
                { }
                mockGameRepo.Verify(r => r.Create(game), Times.Never);
            }
           



        }


    }
}
