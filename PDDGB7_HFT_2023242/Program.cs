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
                    entity = rest.Get<RentLog>(int.Parse(Console.ReadLine()), "RentLogg");
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


        static void Main(string[] args)
        {
            //GamesDbContext ctx = new GamesDbContext();
            //ctx.Developers.ToList().ForEach(game => Console.WriteLine(game.Name));






            Console.WriteLine("Hello World!");
        }
    }
}
