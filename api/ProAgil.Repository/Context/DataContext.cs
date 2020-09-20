using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Model;
using System.Data;

namespace ProAgil.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        
        public DbSet<Evento> Eventos { get; set; }

    }
}



