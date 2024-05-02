using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Models
{
    public class User:Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        
        public virtual ICollection<RentLog> RentLogs { get; set; }
        public User ()
        {
            RentLogs = new List<RentLog>();
        }

        public User(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            Name = split[1];

        }

     }
}
