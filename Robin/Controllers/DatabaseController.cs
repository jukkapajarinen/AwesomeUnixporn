using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Robin
{
    public class DatabaseController : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION");
            if (String.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Error: DB_CONNECTION environment variable is empty.");
            }
            optionsBuilder.UseMySql(connectionString, mysqlOptions => {
                mysqlOptions.ServerVersion(new Version(10, 5), ServerType.MariaDb)
                    .EnableRetryOnFailure();
            });
        }
    }
}