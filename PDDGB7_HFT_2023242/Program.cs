using PDDGB7_HFT_2023242.Repository.Data;
using System;
using System.Linq;
using System.Threading.Channels;

namespace PDDGB7_HFT_2023242
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GamesDbContext ctx=new GamesDbContext();
            ctx.Developers.ToList().ForEach(game => Console.WriteLine(game.Name));


            Console.WriteLine("Hello World!");
        }
    }
}
