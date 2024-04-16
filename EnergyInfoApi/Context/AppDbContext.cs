using EnergyInfoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyInfoApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Localizacao>? Localizacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Localizacao>().HasKey(c => c.LocalizacaoId);
            mb.Entity<Localizacao>().Property(c => c.Nome)
                                    .HasMaxLength(200)
                                    .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.Codigo)
                                    .HasMaxLength(6)
                                    .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.Latitude)
                                   .HasMaxLength(15)
                                   .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.Longitude)
                                   .HasMaxLength(15)
                                   .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.FonteEnergetica)
                                   .HasMaxLength(15)
                                   .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.PowerOutput)
                                   .HasMaxLength(10)
                                   .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.UnidadeMedida)
                                   .HasMaxLength(5)
                                   .IsRequired();
            mb.Entity<Localizacao>().Property(c => c.DataAtualizacao)
                                  .HasMaxLength(15)
                                  .IsRequired();
        }
    }
}
