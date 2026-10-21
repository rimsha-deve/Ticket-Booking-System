using System;
using System.Collections.Generic;
using System.Text;
using TicketBookingSystem.Domain.Entities;

namespace TicketBookingSystem.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task AddAsync(User user, CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}