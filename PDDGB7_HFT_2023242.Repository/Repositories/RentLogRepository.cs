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
    public class RentLogRepository : Repository<RentLog>, IRepository<RentLog>
    {
        public RentLogRepository(GamesDbContext ctx) : base(ctx)
        {
        }

        public override RentLog Read(int id)
        {
            return ctx.RentLogs.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(RentLog item)
        {
            var t = Read(item.Id);
            t.DateOfRent=item.DateOfRent;
            t.UserId=item.UserId;
            t.GameId=item.GameId;
            ctx.SaveChanges();
        }
        public void Create(RentLog item)
        {
            item.Game = ctx.Games.Where(x => x.Id == item.GameId).FirstOrDefault();
            item.User = ctx.Users.Where(x => x.Id == item.UserId).FirstOrDefault();
            ctx.Set<RentLog>().Add(item);
            ctx.SaveChanges();
        }
    }
}
