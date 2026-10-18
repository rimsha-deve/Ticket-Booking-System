using System;
using System.Collections.Generic;
using System.Text;
using TicketBookingSystem.Application.DTOs;

namespace TicketBookingSystem.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }
}
