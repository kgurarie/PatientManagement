using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Context
{
    public abstract class BaseDbContext : DbContext
    {
        private readonly string _configurationKey = "DefaultContextConfiguration";
        private DbContextConfiguration _dbContextConfiguration;


        protected BaseDbContext()
        {
        }

        protected BaseDbContext(string connectionString)
        {
            if (!string.IsNullOrWhiteSpace(connectionString))
            {
                _configurationKey = connectionString;
            }
            SetConfiguration();
        }

        protected BaseDbContext(DbContextOptions<BaseDbContext> options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_dbContextConfiguration.ConnectionString, x => x.MigrationsHistoryTable("__MyMigrationsHistory", "patient"));
        }

        private void SetConfiguration()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var config = new ConfigurationBuilder().SetBasePath(path).AddJsonFile("config.json").Build();
            var connectionString = config.GetChildren().First(config => config.Key.Equals("ConnectionString"));
            _dbContextConfiguration = new DbContextConfiguration()
            {
                ConnectionString = connectionString.Value
            };

        }
    }
}
