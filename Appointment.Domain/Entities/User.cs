using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appointment.Data;

namespace Appointment.Domain.Entities
{
    public class User:IEntity<int>
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? Token { get; set; }
        public string? PhoneNumber { get; set; }
        public bool? isAdmin { get; set; }
    }
}
