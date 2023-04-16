public interface IPasswordGeneratorService
{
    string Generate(int passwordLength, bool upperCase, bool numbers, bool SYMBOLS);
}