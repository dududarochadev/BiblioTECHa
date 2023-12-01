using BiblioTECHa.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberApi.Domain
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>();
        }
    }
}