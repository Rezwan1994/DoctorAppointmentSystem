using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Domain.Entities;

namespace Appointment.Domain.DbContexts
{
    public interface IAppointmentDbContext
    {
        DbSet<Patient> Patients { get; set; }
    }
}
