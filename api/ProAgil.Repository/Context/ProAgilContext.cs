using Microsoft.EntityFrameworkCore;
using ProAgil.Domain.Model;
using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ProAgil.Domain.Identity;

namespace ProAgil.Repository.Context
{
    public class ProAgilContext : IdentityDbContext<User,
                        Role,int,
                        IdentityUserClaim<int>,
                        UserRole,
                        IdentityUserLogin<int>,
                        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options){}
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Lote> Lote { get; set; }
        public DbSet<Palestrante> Palestrante { get; set; }
        public DbSet<PalestranteEvento> PalestranteEvento { get; set; }
        public DbSet<RedeSocial> RedeSocial { get; set; }
       // public DbSet<PrivateCorretora> PrivateCorretoras {get; set;}
        public DbSet<Controle> Controles {get; set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(pe => new {pe.EventoId, pe.PalestranteId});

           base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole => 
                {
                    userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                    userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                    userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired();
                }
            );
        }

    }
}



