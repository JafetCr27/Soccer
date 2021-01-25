using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data.Entities;

namespace Soccer.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<GrupoDetalle> GroupDetails { get; set; }

        public DbSet<Grupo> Groups { get; set; }

        public DbSet<Partido> Matches { get; set; }

        public DbSet<Predicciones> Predictions { get; set; }

        public DbSet<Torneo> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>()
                .HasIndex(t => t.Nombre)
                .IsUnique();
        }
    }
}
