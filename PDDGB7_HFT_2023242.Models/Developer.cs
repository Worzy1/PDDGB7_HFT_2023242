using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Models
{
    public class Developer : Entity
    {
        public override int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [JsonIgnore]
        [NotMapped]
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

        public override string ToString()
        {
            return Id + ": " + Name;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Developer))
                return false;
            Developer developer = obj as Developer;
            return Id == developer.Id && Name == developer.Name;
        }


    }
}
