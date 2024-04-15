using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Classes
{
    internal class BibliotecaContext : DbContext
    {
        public DbSet<Carti> Carti { get; set; } = null!;
        public DbSet<Cititori> Cititori { get; set; } = null!;
        public BibliotecaContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Bibilioteca.db");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carti>().HasKey(p => p.CodCarte);
            modelBuilder.Entity<Cititori>()
                .HasKey(p => p.CodCititor);
            base.OnModelCreating(modelBuilder);
        }
    }
}
