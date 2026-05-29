using System.Collections.Concurrent;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        // very simple in-memory user store: username -> passwordHash
        private readonly ConcurrentDictionary<string, string> _users = new();

        public bool Register(string username, string password)
        {
            var pwd = password ?? string.Empty;
            var hash = HashPassword(pwd);
            return _users.TryAdd(username, hash);
        }

        public bool ValidateCredentials(string username, string password)
        {
            if (!_users.TryGetValue(username, out var storedHash)) return false;
            return VerifyHashedPassword(storedHash, password ?? string.Empty);
        }

        private static string HashPassword(string password)
        {
            // use a simple salted hash for demo purposes
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(password + "__SALT__");
            var hashed = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hashed);
        }

        private static bool VerifyHashedPassword(string hashed, string provided)
        {
            return hashed == HashPassword(provided);
        }
    }
}
