using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Models
{
    public class Developer : Entity
    {
        public override int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public Developer()
        {
            Games = new HashSet<Game>();
        }
        public Developer(string input)
        {
            string[] temp = input.Split('#');
            this.Id = int.Parse(temp[0]);
            this.Name = temp[1];
        }


    }
}
