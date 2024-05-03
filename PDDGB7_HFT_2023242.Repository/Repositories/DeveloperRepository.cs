using NuGet.Protocol.Core.Types;
using PDDGB7_HFT_2023242.Models;
using PDDGB7_HFT_2023242.Repository.Data;
using PDDGB7_HFT_2023242.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Repository.Repositories
{
    public class DeveloperRepository : Repository<Developer>, IRepository<Developer>
    {

        public DeveloperRepository(GamesDbContext ctx) : base(ctx)
        {

        }
        public override Developer Read(int id)
        {
            return ctx.Developers.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Developer item)
        {
            var t = Read(item.Id);
            t.Name = item.Name;
            ctx.SaveChanges();
        }
        public void Delete(int id)
        {
            foreach (var game in Read(id).Games) 
            {
                ctx.Set<RentLog>().RemoveRange(game.RentLogs);
            }
            ctx.Set<Game>().RemoveRange(Read(id).Games);
            ctx.Set<Developer>().Remove(Read(id));
            ctx.SaveChanges() ;
        }
    }
}
