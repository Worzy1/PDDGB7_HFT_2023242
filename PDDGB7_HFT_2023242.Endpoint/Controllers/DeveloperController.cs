using Microsoft.AspNetCore.Mvc;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using System.Collections.Generic;



namespace PDDGB7_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        IDeveloperLogic logic;

        public DeveloperController(IDeveloperLogic logic)
        {
            this.logic = logic;
        }

        
        [HttpGet]
        public IEnumerable<Developer> ReadAll()
        {
            return this.logic.ReadAll();
        }

       
        [HttpGet("{id}")]
        public Developer Read(int id)
        {
            return this.logic.Read(id);
        }

       
        [HttpPost]
        public void Create([FromBody] Developer item)
        {
             this.logic.Create(item);
        }

        [HttpPut]
        public void Put([FromBody] Developer item)
        {
            this.logic.Update(item);
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
