using System;

namespace BankOCR
{
    public class OcrReportingService : IOcrReportingService
    {
        private readonly IAccountNumberValidator _accountNumberValidator;

        public OcrReportingService(IAccountNumberValidator accountNumberValidator) =>
            _accountNumberValidator = accountNumberValidator ?? throw new ArgumentNullException(nameof(accountNumberValidator));

        public string GenerateReport(string accountNumber)
        {
            var isBadInput = accountNumber.Contains("?");
            if (isBadInput) return $"{accountNumber} ILL";

            var isValid = _accountNumberValidator.Validate(accountNumber);
            if (!isValid) return $"{accountNumber} ERR";

            return accountNumber;
        }
    }
}
