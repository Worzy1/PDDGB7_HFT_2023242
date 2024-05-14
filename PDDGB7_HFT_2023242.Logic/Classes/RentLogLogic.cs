using LibGit2Sharp;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Logic.Classes
{
    public class RentLogLogic : IRentLogLogic
    {
        IRepository<RentLog> repo;

        public RentLogLogic(IRepository<RentLog> repo)
        {
            this.repo = repo;
        }

        public void Create(RentLog item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public RentLog Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Can't read non existent entry");
            }
            return item;
        }
        public IQueryable<RentLog> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(RentLog item)
        {
            repo.Update(item);
        }
        public string MostPlayedGameHelper(List<RentLog> logs)
        {
            return logs
                .GroupBy(log => log.Game.Title)
                .GroupBy(g => g.Count())
                .OrderByDescending(g => g.Key)
                .First()
                .Select(log => log.Key)
                .FirstOrDefault();
        }
        public string MostPlayedGame()
        {
            return MostPlayedGameHelper(repo.ReadAll().ToList());
        }

       
        public int BusiestYear()
        {
           return repo.ReadAll().ToList()
                .GroupBy(i=>i.DateOfRent.Year)
                .GroupBy(g=> g.Count())
                .OrderByDescending(g=>g.Key)
                .First()
                .Select (log => log.Key)
                .FirstOrDefault();
        }
        public int BusiestMonth()
        {
            return repo.ReadAll().ToList()
                .GroupBy(i => i.DateOfRent.Month)
                .GroupBy(g => g.Count())
                .OrderByDescending(g => g.Key)
                .First()
                .Select(log => log.Key)
                .FirstOrDefault();
        }
        public int NumberOfDevelopersGamesRentedAtDate(string developerName, DateTime date)
        {
          return (from log in repo.ReadAll()
                  where log.DateOfRent == date && log.Game.Developer.Name == developerName select log).Count();
        }


    }
}
