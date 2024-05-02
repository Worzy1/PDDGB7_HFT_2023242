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
                new Game("2#1#Borderlands 2#2012*09*18"),
                new Game("3#1#Borderlands 3#2019*09*13"),
                new Game("4#2#Diablo 2#2000*06*28"),
                new Game("5#2#Diablo 3#2012*05*15"),
                new Game("6#2#Diablo 4#2023*06*5"),
                new Game("7#3#Minecraft#2011*11*18"),
                new Game("8#4#Warframe#2013*03*25"),
                new Game("9#5#Stardew Valley#2016*02*26"),
                new Game("10#6#CSGO#2012*08*21"),
                new Game("11#6#HalfLife#1998*11*19"),
                new Game("12#6#HalfLife 2#2004*11*16"),
                new Game("13#1#FarCry 5#2018*03*27"),
                new Game("14#7#FarCry 6#2021*10*07"),
                new Game("15#7#Rainbow Six Siege#2015*12*01"),
                new Game("16#8#Apex Legends#2019*02*04"),
                new Game("17#9#League Of Legends#2009*10*27"),
                new Game("18#2#Hearthstone#2014*03*11"),
                new Game("19#10#Skyrim#2011*11*11"),
                new Game("20#10#Fallout 4#2015*11*10")
               
            });
            modelBuilder.Entity<Developer>().HasData(new Developer[]
            {
                new Developer("1#Gearbox Software"),
                new Developer("2#Blizzard"),
                new Developer("3#Mojang"),
                new Developer("4#Digital Extremes"),
                new Developer("5#ConcernedApe"),
                new Developer("6#Valve Software"),
                new Developer("7#Ubisoft"),
                new Developer("8#Respawn Entertainment"),
                new Developer("9#Riot Games"),
                new Developer("10#Bethesda Game Studios")  
            }); 
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User("1#Vasas Lajos#ABC12"),
                new User("2#Deák Imre#ASD51"),
                new User("3#Kis Norbert#LKJ65"),
                new User("4#Nagy Balázs#583JT"),
                new User("5#Lakatos Arnold#LFG66"),
                new User("6#Fekete István#OKJ12"),
                new User("7#Fehér Gizella#NIK99"),
                new User("8#Kovács Ádám#PROG1"),
                new User("9#Hajós Réka#QWE11"),
                new User("10#Antal Áron#1G5W3"),
                new User("11#Nagy Beáta#HGT23"),
                new User("12#Molnár Attila#KLK78"),
                new User("13#Szilágyi János#OE4EV"),
                new User("14#Farkas Petra#LOP51"),
                new User("15#Varga Sándor#87GJ3")
            });
            modelBuilder.Entity<RentLog>().HasData(new RentLog[]
            {
                new RentLog("1#1#1#2023*05*23"),
                new RentLog("2#2#2#2023*04*22"),
                new RentLog("3#3#3#2023*05*27"),
                new RentLog("4#4#4#2024*01*10"),
                new RentLog("5#5#5#2024*02*11"),
                new RentLog("6#6#6#2024*03*05"),
                new RentLog("7#7#7#2023*09*02"),
                new RentLog("8#8#8#2023*11*30"),
                new RentLog("9#9#9#2023*05*22"),
                new RentLog("10#10#10#2024*01*18"),
                new RentLog("11#11#11#2024*02*17"),
                new RentLog("12#12#12#2024*04*26"),
                new RentLog("13#13#13#2023*12*02"),
                new RentLog("14#14#14#2023*12*01"),
                new RentLog("15#15#15#2023*10*13"),
                new RentLog("16#1#16#2023*08*17"),
                new RentLog("17#2#17#2023*06*15"),
                new RentLog("18#3#18#2023*07*26"),
                new RentLog("19#4#19#2024*03*20"),
                new RentLog("20#5#20#2024*04*29")
            });
        }


    }
}
