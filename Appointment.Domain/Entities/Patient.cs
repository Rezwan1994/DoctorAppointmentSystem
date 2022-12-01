using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Data;

namespace Appointment.Domain.Entities
{
    public class Patient:IEntity<int>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public DateTime DateTime { get; set; }
        public string? Token { get; set; }
        public int Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int CityId { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
    }
}
