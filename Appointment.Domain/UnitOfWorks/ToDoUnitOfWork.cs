using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Domain.DbContexts;
using Appointment.Domain.Repositories;

using Appointment.Data;


namespace Appointment.Domain.UnitOfWorks
{
    public class AppointmentUnitOfWork : UnitOfWork, IAppointmentUnitOfWork
    {
        public IAppointmentRepository Jobs { get; private set; }



        public AppointmentUnitOfWork(AppointmentDbContext dbContext,
            IAppointmentRepository AppointmentRepository) : base((DbContext)dbContext)
        {
            Jobs = AppointmentRepository;

        }
    }
}
