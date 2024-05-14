using Microsoft.AspNetCore.Mvc;
using PDDGB7_HFT_2023242.Logic.Interfaces;
using PDDGB7_HFT_2023242.Models;
using System;
using System.Collections.Generic;


namespace PDDGB7_HFT_2023242.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentLogController : ControllerBase
    {
        IRentLogLogic logic;

        public RentLogController(IRentLogLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<RentLog> ReadAll()
        {
            return this.logic.ReadAll();
        }

        
        [HttpGet("{id}")]
        public RentLog Read(int id)
        {
            return this.logic.Read(id);
        }

        
        [HttpPost]
        public void Create([FromBody] RentLog item)
        {
            this.logic.Create(item);
        }


        [HttpPut]
        public void Update([FromBody] RentLog item)
        {
            this.logic.Update(item);
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet("MostPlayedGame/")]
        public string MostPlayedGame() => this.logic.MostPlayedGame();
        [HttpGet("BusiestYear/")]
        public int BusiestYear() => this.logic.BusiestYear();
        [HttpGet("BusiestMonth/")]
        public int BusiestMonth() => this.logic.BusiestMonth();
        
        [HttpGet("NumberOfDevelopersGamesRentedAtDate/{developerName}/{date}")]
        public int NumberOfDevelopersGamesRentedAtDate(string developerName, string date)
        {
            try
            {
                return this.logic.NumberOfDevelopersGamesRentedAtDate(developerName, System.DateTime.Parse(date));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
