namespace AppSellBook.Services.PasswordHashers
{
    public interface IPasswordHashser
    {
        string HashPasswords(string password);
        bool VerifyPassword(string password, string passwordHash);
    }
}
