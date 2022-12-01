using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.BusinessObjects
{
    public class UserDto
    {

        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public string? Email { get; set; }
        public string? DisplayName { get; set; }
        public string? Token { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Role { get; set; }
    }
}
