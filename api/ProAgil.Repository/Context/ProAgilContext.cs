using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Model;
using System.Data;

namespace ProAgil.Repository.Context
{
    public class ProAgilContext : DbContext
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options){}
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(pe => new {pe.EventoId, pe.PalestranteId});
        }

    }
}



