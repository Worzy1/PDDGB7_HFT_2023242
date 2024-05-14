using Microsoft.EntityFrameworkCore.Migrations.Operations;
using NUnit.Framework.Constraints;
using PDDGB7_HFT_2023242.Logic.Classes;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Data;
using PDDGB7_HFT_2023242.Repository.Repositories;
using System;
using System.Linq;
using System.Threading.Channels;

namespace PDDGB7_HFT_2023242
{
    internal class Program
    {

        static void Create(string entityType)
        {
            string id;
            string developerId;
            //switch (entityType)
            //{
            //    case "Developer":
            //        Console.Write("Enter developer's id: ");
            //        id = Console.ReadLine();
            //        Console.Write("Enter developer's name: ");
            //        string developerName = Console.ReadLine();

            //        break;
            //    case "Game":
            //        Console.Write("Enter game's id: ");
            //        id = Console.ReadLine();
            //        Console.Write("Enter developer's id: ");
            //        developerId = Console.ReadLine();
            //        Console.Write("Enter game's title: ");
            //        string title = Console.ReadLine();
            //        Console.Write("Enter game's date of release: ");
            //        string yearOfRelease = Console.ReadLine();

            //        break;
            //    case "User":
            //        Console.Write("Enter user's id: ");
            //        id = Console.ReadLine();
            //        Console.Write("Enter User's refcode: ");
            //        string userRef = Console.ReadLine();


            //}
        }


        static void Main(string[] args)
        {
            //GamesDbContext ctx=new GamesDbContext();
            //ctx.Developers.ToList().ForEach(game => Console.WriteLine(game.Name));
            //var ctx = new GamesDbContext();
            //var repo = new GameRepository(ctx);
            //var logic = new GameLogic(repo);





            Console.WriteLine("Hello World!");
        }
    }
}
