using System;
using System.Security.Cryptography;

public class PasswordSecurity
{
    public static string HashPassword(string password)
    {
        // generate random salt
        byte[] salt = RandomNumberGenerator.GetBytes(16);

        // PBKDF2 hashing
        var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            salt,
            100000,
            HashAlgorithmName.SHA256);

        byte[] hash = pbkdf2.GetBytes(32);

        // store salt + hash together
        return Convert.ToBase64String(salt) + ":" +
               Convert.ToBase64String(hash);
    }

    public static bool VerifyPassword(string password, string storedHash)
    {
        var parts = storedHash.Split(':');
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] stored = Convert.FromBase64String(parts[1]);

        var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            salt,
            100000,
            HashAlgorithmName.SHA256);

        byte[] computed = pbkdf2.GetBytes(32);

        return CryptographicOperations.FixedTimeEquals(stored, computed);
    }
}
