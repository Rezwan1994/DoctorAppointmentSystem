using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Domain.Entities;

namespace Appointment.Domain.Services
{
    public interface IUserService
    {
        void EditTask(Patient task);
        void AddTask(Patient task);
        void UpdateTask(Patient task);
        IList<Patient> GetAll();
        Patient GetById(int id);
        void DeleteTask(int id);
    }
}
