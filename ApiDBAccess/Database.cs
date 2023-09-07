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

        }
    }
}
