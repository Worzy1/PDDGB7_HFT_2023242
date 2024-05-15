using ConsoleTools;
using PDDGB7_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace PDDGB7_HFT_2023242
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entityType)
        {
            string id;
            string developerId;
            switch (entityType)
            {
                case "Developer":
                    Console.Write("Enter developer's id: ");
                    id = Console.ReadLine();
                    Console.Write("Enter developer's name: ");
                    string developerName = Console.ReadLine();
                    rest.Post(new Developer($"{id}#{developerName}"), "Developer");
                    break;
                case "Game":
                    Console.Write("Enter game's id: ");
                    id = Console.ReadLine();
                    Console.Write("Enter developer's id: ");
                    developerId = Console.ReadLine();
                    Console.Write("Enter game's title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter game's date of release: ");
                    string yearOfRelease = Console.ReadLine();
                    rest.Post(new Game($"@{id}#{developerId}#{title}#{yearOfRelease}"), "Game");
                    break;
                case "User":
                    Console.Write("Enter user's id: ");
                    id = Console.ReadLine();
                    Console.Write("Enter user's refcode: ");
                    string userRef = Console.ReadLine();
                    Console.Write("Enter User's name: ");
                    string userName = Console.ReadLine();
                    rest.Post(new User($"{id}#{userName}#{userRef}"), "User");
                    break;
                default:
                    Console.Write("Enter rent log's id: ");
                    id = Console.ReadLine();
                    Console.Write("Enter user's id: ");
                    string userId = Console.ReadLine();
                    Console.Write("Enter game's id: ");
                    string gameId = Console.ReadLine();
                    Console.Write("Enter game's date of release: ");
                    string dateOfRent = Console.ReadLine();
                    rest.Post(new Game($"{id}#{userId}#{gameId}#{dateOfRent}"), "RentLog");
                    break;


            }
        }
        static void List(string entityType)
        {
            List<Entity> entities;
            switch (entityType)
            {
                case "Developer":
                    entities = rest.Get<Developer>("Developer").ToList<Entity>();
                    break;
                case "Game":
                    entities = rest.Get<Game>("Game").ToList<Entity>();
                    break;
                case "User":
                    entities = rest.Get<User>("User").ToList<Entity>();
                    break;
                default:
                    entities = rest.Get<RentLog>("RentLog").ToList<Entity>();
                    break;
            }
            foreach (var item in entities)
                Console.WriteLine(item);
            Console.ReadLine();
        }
        static void Update(string entityType)
        {
            Console.Write($"Enter {entityType}'s id to update: ");
            Entity entity;
            switch (entityType)
            {
                case "Developer":
                    entity = rest.Get<Developer>(int.Parse(Console.ReadLine()), "Developer");
                    Console.Write($"New name [old: {(entity as Developer).Name}]: ");
                    (entity as Developer).Name = Console.ReadLine();
                    rest.Put(entity, "Developer");
                    break;
                case "Game":
                    entity = rest.Get<Game>(int.Parse(Console.ReadLine()), "Game");
                    Console.Write($"New title [old: {(entity as Game).Title}]: ");
                    (entity as Game).Title = Console.ReadLine();
                    Console.Write($"New developer id [old: {(entity as Game).DeveloperId}]: ");
                    (entity as Game).DeveloperId = int.Parse(Console.ReadLine());
                    Console.Write($"New release date [old:{(entity as Game).YearOfRelease}]:");
                    (entity as Game).YearOfRelease = DateTime.Parse(Console.ReadLine());
                    rest.Put(entity, "Game");
                    break;
                case "User":
                    entity = rest.Get<User>(int.Parse(Console.ReadLine()), "User");
                    Console.Write($"New name [old: {(entity as User).Name}]: ");
                    (entity as User).Name = Console.ReadLine();
                    Console.Write($"New refcode[old: {(entity as User).RefCode}]: ");
                    (entity as User).RefCode = Console.ReadLine();
                    rest.Put(entity, "User");
                    break;
                default:
                    entity = rest.Get<RentLog>(int.Parse(Console.ReadLine()), "RentLog");
                    Console.Write($"New date of renting [old: {(entity as RentLog).DateOfRent.ToString().Split(" ")[0]}]: ");
                    (entity as RentLog).DateOfRent = DateTime.Parse(Console.ReadLine());
                    Console.Write($"New user id [old: {(entity as RentLog).UserId}]: ");
                    (entity as RentLog).UserId = int.Parse(Console.ReadLine());
                    Console.Write($"New game id [old: {(entity as RentLog).GameId}]: ");
                    (entity as RentLog).GameId = int.Parse(Console.ReadLine());
                    rest.Put(entity, "RentLog");
                    break;
            }
            rest.Put(entity, entityType);

        }
        static void Delete(string entityType)
        {
            Console.Write($"Enter {entityType}'s id to delete: ");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, entityType);
        }
        //static void GetAllUsersAverageNumberOfRents

        static void AllUsersAvgNumOfRents()
        {
            Console.WriteLine($"The average number of rents/user is {rest.GetAllUsersAverageNumberOfRents()}");
            Console.ReadLine();
        }

        static void FavouriteDeveloper()
        {
            Console.WriteLine("User's Refcode id: ");
            string refcode = Console.ReadLine();
            try
            {
                Console.WriteLine(rest.GetFavouriteDeveloper(refcode) + $"is {refcode}'s favourite developer");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        static void TheMostPlayedGame()
        {
            Console.WriteLine($"The most played game is: {rest.GetMostPlayedGame()}");
            Console.ReadLine();
        }
        static void TheMostPlayedGameDuringBusiestYear()
        {
            Console.WriteLine($"The most played game during the busiest year is: {rest.GetTheBusiestYearsMostPlayedGame()}");
            Console.ReadLine();
        }
        static void NumberOfGamesByDeveloper()
        {
            Console.WriteLine("Developer's name: ");
            string developerName = Console.ReadLine();
            Console.WriteLine($"The number of available games by {developerName} is: {rest.NumberOfGamesByDeveloper(developerName)}");
            Console.ReadLine();
        }
        static void TheNumberOfDevelopersGamesRentedAtDate()
        {
            Console.WriteLine("Developer's name: ");
            string developerName = Console.ReadLine();
            Console.WriteLine("Date: ");
            string date = Console.ReadLine();
            try
            {
                Console.WriteLine($"The number of {developerName}'s games rented on {date} is: {rest.NumberOfDevelopersGamesRentedAtDate(developerName, date)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            Console.ReadLine();
        }


        static void Main(string[] args)
        {

            rest = new RestService("http://localhost:21829/");
            var querySubMenu = new ConsoleMenu(args, level: 1)
                .Add("Average number of rents", () => AllUsersAvgNumOfRents())
                .Add("Student's favourite developer", () => FavouriteDeveloper())
                .Add("Most played game", () => TheMostPlayedGame())
                .Add("Most played game during busiest year", () => TheMostPlayedGameDuringBusiestYear())
                .Add("Number of available games by developer", () => NumberOfGamesByDeveloper())
                .Add("Number of developer's game rented on day", () => TheNumberOfDevelopersGamesRentedAtDate())
                .Add("Exit", ConsoleMenu.Close);

            var developerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Developer"))
                .Add("Create", () => Create("Developer"))
                .Add("Delete", () => Delete("Developer"))
                .Add("Update", () => Update("Developer"))
                .Add("Exit", ConsoleMenu.Close);

            var gameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Exit", ConsoleMenu.Close);

            var rentLogSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("RentLog"))
                .Add("Create", () => Create("RentLog"))
                .Add("Delete", () => Delete("RentLog"))
                .Add("Update", () => Update("RentLog"))
                .Add("Exit", ConsoleMenu.Close);

            var userSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("User"))
                .Add("Create", () => Create("User"))
                .Add("Delete", () => Delete("User"))
                .Add("Update", () => Update("User"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Users", () => userSubMenu.Show())
                .Add("Developers", () => developerSubMenu.Show())
                .Add("Games", () => gameSubMenu.Show())
                .Add("RentLogs", () => rentLogSubMenu.Show())
                .Add("Query menu", () => querySubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
