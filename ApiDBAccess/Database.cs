using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiDTOModels;

namespace ApiDBAccess
{
    public class Database : DbContext
    {
        public DbSet<DtoArtist> Artists { get; set; }
        public DbSet<DtoArtistPayment> ArtistPayments { get; set; }
        public DbSet<DtoBlackList> BlackLists { get; set; }
        public DbSet<DtoFriend> Friends { get; set; }
        public DbSet<DtoPremium> Premia { get; set; }
        public DbSet<DtoSettings> Settings { get; set; }
        public DbSet<DtoUser> Users { get; set; }
        public DbSet<DtoWhiteList> WhiteLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;DataBase=MusikAppDatabase;Integrated Security=True; TrustServerCertificate=true;").UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DtoUser>().HasData(
                new DtoUser { Id = 1, ProfilPicture = "Billede", Name = "Justin", LastName = "Bieber", UserName = "JustinB", Password = "Bruger123", Mail = "justinbieber@hotmail.com", IsPremium = true, IsArtist = true, LastOnline = DateTime.Now.AddDays(1)},
                new DtoUser { Id = 2, ProfilPicture = "Billede1", Name = "Bruce", LastName = "Wayne", UserName = "Batman", Password = "Beuger123", Mail = "batmanerbest@gmail.com", IsPremium = true, IsArtist = false, LastOnline = DateTime.Now.AddHours(1) },
                new DtoUser { Id = 3, ProfilPicture = "Billede2", Name = "Clark", LastName = "Kent", UserName = "Superman", Password = "Bruger123", Mail = "ilovelois@gmail.com", IsPremium = false, IsArtist = false, LastOnline = DateTime.Now });
            modelBuilder.Entity<DtoArtistPayment>().HasData(
                new DtoArtistPayment { Id = 1, ArtistId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now });
            modelBuilder.Entity<DtoArtist>().HasData(
                new DtoArtist { Id = 1, UserId = 1});
            modelBuilder.Entity<DtoFriend>().HasData(
                new DtoFriend { Id = 1, UserId = 2, FriendId = 1},
                new DtoFriend { Id = 2, UserId = 2, FriendId = 3});
            modelBuilder.Entity<DtoPremium>().HasData(
                new DtoPremium { Id = 1, UserId = 1, NextTransactionDay = DateTime.Now, TransactionDay = DateTime.Now },
                new DtoPremium { Id = 2, UserId = 2, NextTransactionDay = DateTime.Now, TransactionDay = DateTime.Now });
            modelBuilder.Entity<DtoSettings>().HasData(
                new DtoSettings { Id = 1, UserId = 1, ChangeGenre = "k-pop", HowNewTheMusicIs = 10, NotificationsAmount = 5 },
                new DtoSettings { Id = 2, UserId = 2, ChangeGenre = "rock", HowNewTheMusicIs = 5, NotificationsAmount = 3 },
                new DtoSettings { Id = 3, UserId = 3, ChangeGenre = "pop", HowNewTheMusicIs = 20, NotificationsAmount = 8 });
            modelBuilder.Entity<DtoBlackList>().HasData(
                new DtoBlackList { Id = 1, UserID = 1, SongID = "7xapw9Oy21WpfEcib2ErSA" },
                new DtoBlackList { Id = 2, UserID = 2, SongID = "7xapw9Oy21WpfEcib2ErSA" },
                new DtoBlackList { Id = 3, UserID = 3, SongID = "7xapw9Oy21WpfEcib2ErSA"});
            modelBuilder.Entity<DtoWhiteList>().HasData(
                new DtoWhiteList { Id = 1, UserID = 1, SongID = "6habFhsOp2NvshLv26DqMb" },
                new DtoWhiteList { Id = 2, UserID = 2, SongID = "6habFhsOp2NvshLv26DqMb" },
                new DtoWhiteList { Id = 3, UserID = 3, SongID = "6habFhsOp2NvshLv26DqMb" });
        }
    }
}
