using System;
using System.Collections.Generic;
using System.Text;

namespace TicketBookingSystem.Application.Interfaces.Services.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(int userId, string email, string role);
    }
}
