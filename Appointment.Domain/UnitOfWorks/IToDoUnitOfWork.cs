using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Data;
using Appointment.Domain.Repositories;

namespace Appointment.Domain.UnitOfWorks
{
    public interface IAppointmentUnitOfWork : IUnitOfWork
    {
        IAppointmentRepository Jobs { get; }

    }
}
