using PDDGB7_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Logic.Interfaces
{
    public interface IUserLogic
    {
        void Create(User item);
        void Delete(int id);
        User Read(int id);
        IQueryable<User> ReadAll();
        void Update(User item);
        public double GetAllUsersAverageNumberOfRents();
        public string GetMostRentedDeveloper(string refcode);



    }
}
