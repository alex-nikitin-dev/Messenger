using System;
using System.Security.Cryptography;
using System.Text;

namespace ServerInterfaceLib
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password)
        {
            // generate 16-byte salt
            var saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            var salt = Convert.ToBase64String(saltBytes);

            using (var sha = SHA256.Create())
            {
                var combined = Encoding.UTF8.GetBytes(salt + password);
                var hash = sha.ComputeHash(combined);
                return salt + "$" + Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string inputPassword, string stored, out string migrated)
        {
            migrated = stored;
            if (string.IsNullOrEmpty(stored)) return false;
            var parts = stored.Split('$');
            if (parts.Length == 2)
            {
                // hashed format
                var salt = parts[0];
                var hash = parts[1];
                using (var sha = SHA256.Create())
                {
                    var combined = Encoding.UTF8.GetBytes(salt + inputPassword);
                    var newHash = Convert.ToBase64String(sha.ComputeHash(combined));
                    return string.Equals(hash, newHash, StringComparison.Ordinal);
                }
            }
            // fallback plaintext
            if (stored == inputPassword)
            {
                migrated = HashPassword(inputPassword);
                return true;
            }
            return false;
        }
    }
}
