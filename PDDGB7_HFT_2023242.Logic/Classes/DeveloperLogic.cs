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
    public class DeveloperLogic : IDeveloperLogic
    {
        IRepository<Developer> repo;

        public DeveloperLogic(IRepository<Developer> repo)
        {
            this.repo = repo;
        }

        public void Create(Developer item)
        {
            if (item.Name.Equals(""))
            {
                throw new ArgumentNullException("No developer name");
            }
            repo.Create(item);
        }


        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Developer Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Can't read non existent entry");
            }
            return item;
        }

        public IQueryable<Developer> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Developer item)
        {
            repo.Update(item);
        }

        
    }
}
