using System.Security.Cryptography;
using System.Text;

namespace LibraryAPI.Utils
{
    internal class PasswordUtils
    {
        internal static byte[] GenerateSalt(int size = 16)
        {
            byte[] salt = new byte[size];
            try
            {
                RandomNumberGenerator.Fill(salt);
                return salt;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return salt;
        }

        internal static string HashPassword(string password, byte[] salt)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                    byte[] saltedPassword = new byte[salt.Length + passwordBytes.Length];

                    Buffer.BlockCopy(passwordBytes, 0, saltedPassword, 0, passwordBytes.Length);
                    Buffer.BlockCopy(salt, 0, saltedPassword, passwordBytes.Length, salt.Length);

                    byte[] hashedBytes = sha256.ComputeHash(saltedPassword);

                    byte[] hashedPassWithSalt = new byte[hashedBytes.Length + salt.Length];
                    Buffer.BlockCopy(salt, 0, hashedPassWithSalt, 0, salt.Length);
                    Buffer.BlockCopy(hashedBytes, 0, hashedPassWithSalt, salt.Length, hashedBytes.Length);

                    return Convert.ToBase64String(hashedPassWithSalt);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}
