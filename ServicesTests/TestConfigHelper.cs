using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicesTests
{
    public static class TestConfigHelper
    {
        public static string GetDefaultConnectionString()
        {
            var config = InitConfiguration();
            var connectionString = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }

        public static IConfiguration InitConfiguration(string appsettingsFile = "appsettings.test.json")
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile(appsettingsFile)
                         .Build();
            return config;
        }
        public static DbContextOptionsBuilder<PatientDbContext> GetDbContextOptionsBuilder()
        {
            var builder = new DbContextOptionsBuilder<PatientDbContext>();
            var connectionString = GetDefaultConnectionString();
            builder.UseSqlServer(connectionString, optionsAction => optionsAction.EnableRetryOnFailure());
            return builder;
        }
    }
}
