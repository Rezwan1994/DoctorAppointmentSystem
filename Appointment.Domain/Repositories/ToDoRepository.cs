using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Data;
using Appointment.Domain.DbContexts;
using Appointment.Domain.Entities;

namespace Appointment.Domain.Repositories
{
    public class AppointmentRepository : Repository<Patient, int>, IAppointmentRepository
    {
        public AppointmentRepository(AppointmentDbContext context) : base((DbContext)context)
        {
        }
    }
}
