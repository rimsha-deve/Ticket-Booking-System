using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TicketBookingSystem.Application.DTOs;
using TicketBookingSystem.Application.DTOs.Login;
using TicketBookingSystem.Application.Interfaces.Repositories;
using TicketBookingSystem.Application.Interfaces.Services.Auth;
using TicketBookingSystem.Domain.Entities;
using TicketBookingSystem.Domain.Exceptions;


namespace TicketBookingSystem.Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        private readonly AutoMapper.IMapper _mapper;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository, AutoMapper.IMapper mapper)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AuthResponse>> RegisterAsync(RegisterRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var existingUser = await _userRepository.ExistsByEmailAsync(email);

            if (existingUser)
            {
                throw new DuplicateEntity("An account with this email already exists.");
            }

            var user = new User
            {
                FullName = request.FullName.Trim(),
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(
                    request.Password),
                Role = "Customer",
              //  CreatedAt = DateTime.UtcNow
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var token = _jwtTokenGenerator.GenerateToken(
                user.Id,
                user.Email,
                user.Role);
            var authResponse = _mapper.Map<AuthResponse>(user);
            authResponse.Token = token;

            return ApiResponse<AuthResponse>.SuccessResponse(authResponse, 200, "Registration successful.");
        }

        public async Task<ApiResponse<AuthResponse>> LoginAsync(LoginRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null ||
                !BCrypt.Net.BCrypt.Verify(
                    request.Password, user.PasswordHash))
            {
                throw new UnauthorizedException("Invalid email or password.");
            }

            var token = _jwtTokenGenerator.GenerateToken(
                user.Id,
                user.Email,
                user.Role);
            var authResponse = _mapper.Map<AuthResponse>(user);

            authResponse.Token = token;

            return ApiResponse<AuthResponse>.SuccessResponse(authResponse,200, "Login successful.");
        }
    }
}