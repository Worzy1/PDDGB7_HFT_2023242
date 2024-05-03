using LibGit2Sharp;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Data;
using PDDGB7_HFT_2023242.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PDDGB7_HFT_2023242.Repository.Repositories
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(GamesDbContext ctx) : base(ctx)
        {
        }

        public override User Read(int id)
        {
            return ctx.Users.FirstOrDefault(x => x.Id == id);
        }
        public void Create(User item)
        {
            item.RefCode = item.RefCode.ToUpper();
            ctx.Set<User>().Add(item);
            ctx.SaveChanges();
        }

        public override void Update(User item)
        {
            var t = Read(item.Id);
            t.Name = item.Name;
            t.RefCode = item.RefCode.ToUpper();
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<RentLog>().RemoveRange(Read(id).RentLogs);
            ctx.Set<User>().Remove(Read(id));
            ctx.SaveChanges();
        }
    }
}
