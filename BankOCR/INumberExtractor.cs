namespace BankOCR
{
    public interface INumberExtractor
    {
        string ExtractFirstNumber(string input);
        string ExtractOtherNumbers(string input);
    }
}