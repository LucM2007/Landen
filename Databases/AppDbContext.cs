using Landen.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Landen.Databases
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Land> Landen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Fetch the connection string by name 'MyConnStr'
                var connStr = ConfigurationManager.ConnectionStrings["MyConnStr"].ConnectionString;
                optionsBuilder.UseMySQL(connStr);
            }
        }
    }
}
