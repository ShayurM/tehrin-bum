using Microsoft.AspNetCore.Identity;

namespace APDS3.Server.Services
{
    public class PasswordHasherService
    {
        private readonly PasswordHasher<IdentityUser> _passwordHasher;

        public PasswordHasherService()
        {
            _passwordHasher = new PasswordHasher<IdentityUser>();
        }

        // Hash a password for storage
        public string HashPassword(string password)
        {
            var dummyUser = new IdentityUser();
            return _passwordHasher.HashPassword(dummyUser, password);
        }

        // Verify a password against a stored hash
        public bool VerifyPassword(string hashedPassword, string password)
        {
            var dummyUser = new IdentityUser();
            var result = _passwordHasher.VerifyHashedPassword(dummyUser, hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
