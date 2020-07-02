using Microsoft.EntityFrameworkCore;
using ProAgil.WebAPI.Model;
using Microsoft.Data.Sqlite;

namespace ProAgil.WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Evento> Eventos { get; set; }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
          modelBuilder.Entity<Evento>().ToTable("Evento");
       }
    }
}