using Appointment.Common;
using Appointment.Membership.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Membership.Services
{
    public interface ITokenRefresher
    {
        public Task<AuthorizeResponse> Refresh(RefreshCred refreshCred);
    }
}
