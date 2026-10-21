using System;
using System.Collections.Generic;
using System.Text;
using TicketBookingSystem.Application.DTOs;
using TicketBookingSystem.Application.DTOs.Login;

namespace TicketBookingSystem.Application.Interfaces.Services.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest request);
        Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request);

    }
}
