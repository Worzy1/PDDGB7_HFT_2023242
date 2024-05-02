using Microsoft.EntityFrameworkCore;
using PDDGB7_HFT_2023242.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDDGB7_HFT_2023242.Repository.Data
{
    public class GamesDbContext : DbContext
    {
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<RentLog> RentLogs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public GamesDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("gamesdb")
                    .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>()
                .HasMany(developer => developer.Games)
                .WithOne(game => game.Developer)
                .HasForeignKey(game => game.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Game>()
                .HasOne(game => game.Developer)
                .WithMany(developer => developer.Games)
                .HasForeignKey(game => game.DeveloperId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
                .HasMany(user => user.RentLogs)
                .WithOne(log => log.User)
                .HasForeignKey(user => user.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<RentLog>()
                .HasOne(log => log.Game)
                .WithMany(game => game.RentLogs)
                .HasForeignKey(log => log.GameId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<RentLog>()
                .HasOne(log => log.User)
                .WithMany(user => user.RentLogs)
                .HasForeignKey(log => log.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Game>().HasData(new Game[]
            {
                new Game("1#1#Borderlands#2009*10*20"),
                new Game("2#1#Borderlands2#2012*09*18"),
                new Game("3#1#Borderlands3#2019*09*13"),
                new Game("4#2#Diablo2#2000*06*28"),
                new Game("5#2#Diablo3#2012*05*15"),
                new Game("6#2#Diablo4#2023*06*5"),
                new Game("7#3#Minecraft#2011*11*18"),
                new Game("8#4#Warframe#2013*03*25"),
                new Game("9#5#StardewValley#2016*02*26"),
                new Game("10#1#Borderlands#2009*10*20"),
                new Game("1#1#Borderlands#2009*10*20"),
                new Game("12#1#Borderlands#2009*10*20"),
                new Game("13#1#Borderlands#2009*10*20"),
                new Game("14#1#Borderlands#2009*10*20"),
                new Game("15#1#Borderlands#2009*10*20"),
                new Game("16#1#Borderlands#2009*10*20"),
                new Game("17#1#Borderlands#2009*10*20"),
                new Game("18#1#Borderlands#2009*10*20"),
                new Game("19#1#Borderlands#2009*10*20"),
                new Game("20#1#Borderlands#2009*10*20"),
                new Game("21#1#Borderlands#2009*10*20"),
                new Game("22#1#Borderlands#2009*10*20"),
                new Game("23#1#Borderlands#2009*10*20"),
                new Game("24#1#Borderlands#2009*10*20"),
                new Game("25#1#Borderlands#2009*10*20"),
                new Game("26#1#Borderlands#2009*10*20"),

            });;
            modelBuilder.Entity<Developer>().HasData(new Developer[]
            {
                new Developer("1#Gearbox"),
                new Developer("2#Blizzard"),
                new Developer("3#Mojang"),
                new Developer("4#DigitalExtremes"),
                new Developer("5#ConcernedApe"),
                
                

            }); ;

        }


    }
}
