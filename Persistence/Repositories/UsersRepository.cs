using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DbSet<User> _users;

        public UsersRepository(DataContext context) =>
            _users = context.Set<User>();

        public async Task<IEnumerable<User>> GetAllAsync() =>
            await _users.Include(u => u.Photos).AsNoTracking().ToListAsync();

        public async Task<User> GetByIdAsync(Guid id) =>
            await _users.Include(u => u.Photos).SingleOrDefaultAsync(u => u.Id == id);

        public async Task<User> GetByUsernameAsync(string username) =>
            await _users.Include(u => u.Photos).SingleOrDefaultAsync(u => u.UserName == username);
    }
}