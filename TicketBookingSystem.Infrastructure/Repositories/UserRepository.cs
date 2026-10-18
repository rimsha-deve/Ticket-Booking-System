using Microsoft.EntityFrameworkCore;
using TicketBookingSystem.Application.Interfaces.Repositories;
using TicketBookingSystem.Domain.Entities;
using TicketBookingSystem.Infrastructure.Persistence;

namespace TicketBookingSystem.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketBookingDbContext _context;

        public UserRepository(TicketBookingDbContext context)
        {
            _context = context;
        }

        public Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
            => _context.Users.AnyAsync(u => u.Email == email, cancellationToken);

        public Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
            => _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        public async Task AddAsync(User user, CancellationToken cancellationToken = default)
            => await _context.Users.AddAsync(user, cancellationToken);

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => _context.SaveChangesAsync(cancellationToken);
    }
}