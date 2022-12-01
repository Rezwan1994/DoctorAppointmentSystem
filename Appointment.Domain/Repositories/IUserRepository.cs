using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Data;
using Appointment.Domain.Entities;

namespace Appointment.Domain.Repositories
{
   
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
