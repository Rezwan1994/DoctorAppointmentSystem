using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Membership.Services
{
    public interface IRefreshTokenGeneratorService
    {
        Task<string> GenerateRefreshToken();
    }
}
