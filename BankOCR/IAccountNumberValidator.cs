namespace BankOCR
{
    public interface IAccountNumberValidator
    {
        bool Validate(string accountNumberString);
    }
}