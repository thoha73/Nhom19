using Org.BouncyCastle.Crypto.Generators;

namespace AppSellBook.Services.PasswordHashers
{
    public class BcryptPasswordHasher : IPasswordHashser
    {
        public string HashPasswords(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
