using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Application.DTOs;
using TicketBookingSystem.Application.Interfaces.Repositories;
using TicketBookingSystem.Application.Interfaces.Services;
using TicketBookingSystem.Domain.Entities;

namespace TicketBookingSystem.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var existingUser = await _userRepository.ExistsByEmailAsync(email);

            if (existingUser)
            {
                throw new InvalidOperationException(
                    "An account with this email already exists.");
            }

            var user = new User
            {
                FullName = request.FullName.Trim(),
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
                    request.Password),
                Role = "Customer",
                CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(
                user.Id,
                user.Email,
                user.Role);

            return new AuthResponse
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            };
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(
                    request.Password, user.PasswordHash))
            {
                throw new UnauthorizedAccessException(
                    "Invalid email or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(
                user.Id,
                user.Email,
                user.Role);

            return new AuthResponse
            {
                Token = token,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}