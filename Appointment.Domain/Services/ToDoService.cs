using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Domain.Entities;
using Appointment.Domain.UnitOfWorks;

namespace Appointment.Domain.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentUnitOfWork _AppointmentUnitOfWork;


        public AppointmentService(IAppointmentUnitOfWork AppointmentUnitOfWork)
        {
            _AppointmentUnitOfWork = AppointmentUnitOfWork;

        }
        public void AddTask(Patient task)
        {
            var taskCount = _AppointmentUnitOfWork.Jobs
                .GetCount(x => x.Name == task.Name);

            if (taskCount == 0)
            {
                _AppointmentUnitOfWork.Jobs.Add(task);
                _AppointmentUnitOfWork.Save();
            }

        }
        public void EditTask(Patient task)
        {
            var studentEntity = _AppointmentUnitOfWork.Jobs.GetById(task.Id);

            _AppointmentUnitOfWork.Save();
        }


        public void DeleteTask(int id)
        {
            _AppointmentUnitOfWork.Jobs.Remove(id);
            _AppointmentUnitOfWork.Save();
        }

        public IList<Patient> GetAll()
        {
            return _AppointmentUnitOfWork.Jobs.GetAll();
        }

        public Patient GetById(int id)
        {
            return _AppointmentUnitOfWork.Jobs.GetById(id);
        }
        public void UpdateTask(Patient task)
        {
            _AppointmentUnitOfWork.Jobs.Edit(task);
            _AppointmentUnitOfWork.Save();
        }

     

        IList<Patient> IAppointmentService.GetAll()
        {
            return _AppointmentUnitOfWork.Jobs.GetAll();
        }

        Patient IAppointmentService.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
