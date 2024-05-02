using LibGit2Sharp;
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
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected GamesDbContext ctx;
        protected Repository(GamesDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }
        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public abstract T Read(int id);
        

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public abstract void Update(T item);
    }
}
