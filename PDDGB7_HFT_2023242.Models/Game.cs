using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Models
{
    public class Game : Entity
    {
        public override int Id { get; set; }
        public virtual Developer Developer { get; set; }
        [ForeignKey(nameof(Developer))]
        public int DeveloperId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        public virtual ICollection<RentLog> RentLogs { get; set; }
        public DateTime YearOfRelease { get; set; }

        public Game()
        {
            RentLogs = new List<RentLog>();
        }

        public Game(string line)
        {
            string[] split = line.Split('#');
            Id = int.Parse(split[0]);
            DeveloperId = int.Parse(split[1]);
            Title = split[2];
            YearOfRelease = DateTime.Parse(split[3].Replace('*','.'));
        }

     

    }
}
