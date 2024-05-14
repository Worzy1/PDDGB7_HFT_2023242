using Microsoft.AspNetCore.Mvc;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using System.Collections.Generic;


namespace PDDGB7_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserLogic logic;

        public UserController(IUserLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<User> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public User Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] User item)
        {
            this.logic.Create(item);
        }

        [HttpPut]
        public void Put([FromBody] User item)
        {
            this.logic.Update(item);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("mostLikedDeveloperOf/{refcode}")]
        public string GetMostLikedDeveloperOfUser(string refcode)
        {

            return this.logic.GetMostLikedDeveloper(refcode);

        }

        [HttpGet("averageNumOfRents/")]
        public double GetAllUsersAverageNumberOfRents() => this.logic.GetAllUsersAverageNumberOfRents();
    }
}
