using DatingAPP.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAPP.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public Task<bool> IsUserExists(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<User> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CeatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }





        private void CeatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                passwordSalt = hmac.Key;
            }
        }
    }
}
