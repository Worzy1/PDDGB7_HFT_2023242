using Microsoft.AspNetCore.Mvc;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using System.Collections.Generic;



namespace PDDGB7_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {

        IGameLogic logic;

        public GameController(IGameLogic logic)
        {
            this.logic = logic;
        }

        
        [HttpGet]
        public IEnumerable<Game> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public Game Read(int id)
        {
            return this.logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] Game item)
        {
            this.logic.Create(item);
        }

        
        [HttpPut]
        public void Put([FromBody] Game item)
        {
            this.logic.Update(item);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
