using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Models
{
    public class User:Entity
    {
        public override int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength (5)]
        public string RefCode { get; set; }

        [JsonIgnore]
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
            RefCode = split[2]; 
        }
        public override string ToString()
        {
            return $"{Id}: {Name} ({RefCode})";
        }
        public override bool Equals(object obj)
        {
            if (!(obj is User))
                return false;
            User user = obj as User;
            return Id == user.Id && Name == user.Name && RefCode == user.RefCode;

        }

    }
}
