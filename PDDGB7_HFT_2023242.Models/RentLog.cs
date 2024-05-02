using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Models
{
    public class RentLog : Entity
    {
        public override int Id { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime DateOfRent { get; set; }
        public RentLog()
        {

        }
        public RentLog(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            UserId = int.Parse(split[1]);
            GameId = int.Parse(split[2]);
            DateOfRent = DateTime.Parse(split[3].Replace('*','.'));
        }

    }
}
