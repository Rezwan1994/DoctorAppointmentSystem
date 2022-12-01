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
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(AppointmentDbContext context) : base((DbContext)context)
        {
        }
    }
}
