using System.Security.Cryptography;
using System.Text;

namespace lab5;

public static class PasswordHasher
{
    public static string Hash(string password)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = SHA256.HashData(bytes);

        return Convert.ToHexString(hash);
    }
}