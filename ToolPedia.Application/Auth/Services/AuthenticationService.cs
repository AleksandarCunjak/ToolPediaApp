using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToolPedia.Application.Common.Interfaces;
using ToolPedia.Domain.Entities;

namespace ToolPedia.Application.Auth.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordHasher _passwordHasher;
        private readonly IToolPediaDbContext _context;

        public AuthenticationService(IPasswordHasher passwordHasher, IToolPediaDbContext context)
        {
            _passwordHasher = passwordHasher;
            _context = context;
        }

        public async Task<Guid> RegisterUser(string userName, string password)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(
                x => x.UserName == userName
            );

            if (existingUser is not null)
            {
                return Guid.Empty;
            }

            var passwordHash = _passwordHasher.HashPassword(password, out string salt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                PasswordHash = passwordHash,
                PasswordSalt = salt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(CancellationToken.None);

            return user.Id;
        }

        public async Task<Guid> ValidateCredentials(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName);

            if (
                user != null
                && _passwordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt)
            )
            {
                return user.Id;
            }

            return Guid.Empty;
        }
    }
}
