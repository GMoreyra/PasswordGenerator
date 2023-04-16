using FluentAssertions;
using Xunit;
using PasswordGenerator.Utils;
using PasswordGenerator.Services;

namespace PasswordGenerator.Tests
{
    public class PasswordGeneratorServiceTests
    {
        [Theory]
        [InlineData(16, true, true, true)]
        [InlineData(12, true, true, false)]
        [InlineData(8, false, true, true)]
        [InlineData(9, true, false, true)]
        [InlineData(15, false, true, false)]
        [InlineData(10, false, false, false)]
        public void Generate_GeneratesPasswordWithCorrectParameters(int length, bool upperCase, bool numbers, bool symbols)
        {
            var passwordGeneratorService = new PasswordGeneratorService();

            string password = passwordGeneratorService.Generate(length, upperCase, numbers, symbols);

            password.Should().NotBeNull();
            password.Should().HaveLength(length);

            if (upperCase)
            {
                password.Should().ContainAny(PasswordGeneratorConstants.UPPERCASE_CHARS.Select(c => c.ToString()));
            }

            if (numbers)
            {
                password.Should().ContainAny(PasswordGeneratorConstants.NUMBERS.Select(c => c.ToString()));
            }

            if (symbols)
            {
                password.Should().ContainAny(PasswordGeneratorConstants.SYMBOLS.Select(c => c.ToString()));
            }
        }
    }
}