using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.BusinessObjects
{
    public class LoginDto
    {
      
        public string email { get; set; }

        public string userName { get; set; }

        public string password { get; set; }


        public bool RememberMe { get; set; }

    }
}
