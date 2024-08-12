using System.Security.Cryptography;

namespace LibraryAPI.Utils
{
    internal class PasswordUtils
    {
        internal static byte[] GenerateSalt(int size = 16)
        {
            byte[] salt = new byte[size];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }
    }
}
