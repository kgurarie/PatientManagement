using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class PatientDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PatientAdmission> PatientAdmissions { get; set; }

        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .ToTable("Patient");

            modelBuilder.Entity<State>()
                .ToTable("State");

            modelBuilder.Entity<PatientAdmission>()
                .ToTable("PatientAdmission");

            base.OnModelCreating(modelBuilder);
        }
    }
}
