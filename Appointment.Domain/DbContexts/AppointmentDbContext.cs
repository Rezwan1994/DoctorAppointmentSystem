using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Domain.Entities;

namespace Appointment.Domain.DbContexts
{
    public class AppointmentDbContext : DbContext, IAppointmentDbContext
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public AppointmentDbContext(string connectionString, string assemblyName)
        {
            _assemblyName = assemblyName;
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_assemblyName));

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Patient> Patients { get; set; }

    }
}
