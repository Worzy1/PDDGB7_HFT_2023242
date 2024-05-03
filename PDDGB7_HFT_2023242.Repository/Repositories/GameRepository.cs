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
    public class GameRepository : Repository<Game>, IRepository<Game>
    {
        public GameRepository(GamesDbContext ctx) : base(ctx)
        {
        }

        public override Game Read(int id)
        {
            return ctx.Games.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Game item)
        {
            var t = Read(item.Id);
            t.Title = item.Title;
            t.YearOfRelease = item.YearOfRelease;
            t.DeveloperId = item.DeveloperId;
            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            ctx.Set<RentLog>().RemoveRange(Read(id).RentLogs);
            ctx.Set<Game>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public void Create(Game item)
        {
            item.Developer = ctx.Developers.Where(t => t.Id == item.DeveloperId).FirstOrDefault();
            ctx.Set<Game>().Add(item);
            ctx.SaveChanges();
        }
    }
}
