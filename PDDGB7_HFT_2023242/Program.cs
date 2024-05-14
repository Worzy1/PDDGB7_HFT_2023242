using PDDGB7_HFT_2023242.Models;
using System;
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


        static void Main(string[] args)
        {
            //GamesDbContext ctx = new GamesDbContext();
            //ctx.Developers.ToList().ForEach(game => Console.WriteLine(game.Name));






            Console.WriteLine("Hello World!");
        }
    }
}
