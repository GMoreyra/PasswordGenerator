using System.Security.Cryptography;
using System.Text;
using PasswordGenerator.Utils;

namespace PasswordGenerator.Services
{
    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        public string Generate(int passwordLength, bool upperCase, bool numbers, bool symbols)
        {
            var stringBuilder = new StringBuilder(passwordLength);
            using var rng = RandomNumberGenerator.Create();
            var allowedChars = GetAllowedChars(upperCase, numbers, symbols);

            for (int i = 0; i < passwordLength; i++)
            {
                byte[] randomByte = new byte[1];
                rng.GetBytes(randomByte);
                int randomIndex = randomByte[0] % allowedChars.Length;
                stringBuilder.Append(allowedChars[randomIndex]);
            }

            return stringBuilder.ToString();
        }

        private string GetAllowedChars(bool upperCase, bool numbers, bool symbols)
        {
            var charsAllowed = PasswordGeneratorConstants.LOWERCASE_CHARS;

            if (upperCase)
            {
                charsAllowed += PasswordGeneratorConstants.UPPERCASE_CHARS;
            }
            if  (numbers)
            {
                charsAllowed += PasswordGeneratorConstants.NUMBERS;
            }
            if (symbols)
            {
                charsAllowed += PasswordGeneratorConstants.SYMBOLS;
            }

            return charsAllowed;
        }
    }
}