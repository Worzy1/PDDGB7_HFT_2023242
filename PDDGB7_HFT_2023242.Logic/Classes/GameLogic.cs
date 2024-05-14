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
    public class GameLogic : IGameLogic
    {
        IRepository<Game> repo;

        public GameLogic(IRepository<Game> repo)
        {
            this.repo = repo;
        }

        public void Create(Game item)
        {
            if (item.Title.Equals(""))
            {
                throw new ArgumentException("No game title");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }


        public Game Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Can't read non existent entry");
            }
            return item;
        }
        public IQueryable<Game> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Game item)
        {
            repo.Update(item);
        }

        

        public int NumberOfGamesByDeveloper(string developerName)
        {
            return repo.ReadAll().Where(x => x.Developer.Name == developerName).Count();
        }


    }
}
