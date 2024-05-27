using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Data
{
    public class BankDbContext:DbContext
    {
        public BankDbContext()
        {
            this.Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DVG6JGB\\SQLEXPRESS;Database=BankSystem;" + 
                    "Integrated Security=true;TrustServerCertificate=true;");
            }
        }
        public DbSet<Bank> Banks { get; set; }
    }
}
