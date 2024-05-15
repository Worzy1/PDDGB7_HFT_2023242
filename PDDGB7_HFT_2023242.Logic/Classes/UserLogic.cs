using LibGit2Sharp;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            if (item.RefCode.Equals(""))
            {
                throw new ArgumentException("No refcode given");
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
             repo.Update(item);
        }

        public double GetAllUsersAverageNumberOfRents()
        {
            return repo.ReadAll().Average(t => t.RentLogs.Count());
        }

        public string GetMostLikedDeveloper(string refcode)
        {
            string developer;
            try
            {
                developer = repo.Read(FindId(refcode)).RentLogs
                    .GroupBy(log => log.Game.Developer)
                    .GroupBy(g => g.Count())
                    .OrderByDescending(g => g.Key)
                    .First()
                    .Select(log => log.Key.Name)
                    .FirstOrDefault();
            }
            catch
            {
                developer = "has not played any books yet";
            }
            return developer;
        }

        public int FindId(string refcode)
        {
            foreach(User user in repo.ReadAll())
                if (user.RefCode ==refcode)
                    return user.Id;
            throw new ArgumentException(refcode);
        }

        

       
    }
}
