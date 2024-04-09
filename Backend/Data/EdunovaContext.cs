

using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class EdunovaContext:DbContext
    {
        public EdunovaContext(DbContextOptions<EdunovaContext> options) 
            : base(options) { 

        }

        public DbSet<Mjesto> Mjesta { get; set; }

        public DbSet<Korisnik> Korisnici { get; set; }

        public DbSet<Relacija> Relacije { get; set; }

        public DbSet<Racun> Racuni  { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Relacija>().HasOne(g => g.Odrediste);
            modelBuilder.Entity<Relacija>().HasOne(g => g.Polaziste);

            modelBuilder.Entity<Racun>().HasOne(g => g.Korisnik);








        }

    }
}
