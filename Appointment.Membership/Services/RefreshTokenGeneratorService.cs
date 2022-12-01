﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Membership.Services
{
    public class RefreshTokenGeneratorService : IRefreshTokenGeneratorService
    {
        public async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
                return  Convert.ToBase64String(randomNumber);
            }
        }
    }
}
