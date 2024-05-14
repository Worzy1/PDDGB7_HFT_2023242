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
    public class UserLogic : IUserLogic
    {
        IRepository<User> repo;

        public UserLogic(IRepository<User> repo)
        {
            this.repo = repo;
        }

        public void Create(User item)
        {
            if (!item.Name.Contains(" "))
            {
                throw new ArgumentException("Not full name");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public User Read(int id)
        {
            var item = repo.Read(id);
            if (item == null)
            {
                throw new ArgumentException("Can't read entry that does not exist");
            }
            return item;
        }

        public IQueryable<User> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(User item)
        {
             repo.Create(item);
        }

        public double GetAllUsersAverageNumberOfRents()
        {
            throw new NotImplementedException();
        }

        public string GetMostLikedDeveloper(string refcode)
        {
            throw new NotImplementedException();
        }

        

       
    }
}
