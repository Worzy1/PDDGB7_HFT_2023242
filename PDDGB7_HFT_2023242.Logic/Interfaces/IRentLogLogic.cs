using PDDGB7_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Logic.Interfaces
{
    public interface IRentLogLogic
    {
        void Create(RentLog item);
        void Delete(int id);
        RentLog Read(int id);
        IQueryable<RentLog> ReadAll();
        void Update(RentLog item);
        public int BusiestYear();
        public int BusiestMonth();
        public string MostPlayedGame();
        public int NumberOfDevelopersGamesRentedAtDate(string developerName, DateTime date);

        public string TheBusiestYearsMostPlayedGame();



    }
}
