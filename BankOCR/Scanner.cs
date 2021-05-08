using System.Collections.Generic;

namespace BankOCR
{
    public class Scanner : IScanner
    {
        private readonly INumberExtractor _numberExtractor;

        public Scanner(INumberExtractor numberExtractor) =>
            _numberExtractor = numberExtractor ?? throw new System.ArgumentNullException(nameof(numberExtractor));

        private readonly Dictionary<string, string> _ocrNumberDictionary = new Dictionary<string, string>
        {
            { NumberOcrStrings.ZERO, "0" },
            { NumberOcrStrings.ONE, "1" },
            { NumberOcrStrings.TWO, "2" },
            { NumberOcrStrings.THREE, "3" },
            { NumberOcrStrings.FOUR, "4" },
            { NumberOcrStrings.FIVE, "5" },
            { NumberOcrStrings.SIX, "6" },
            { NumberOcrStrings.SEVEN, "7" },
            { NumberOcrStrings.EIGHT, "8" },
            { NumberOcrStrings.NINE, "9" },
        };

        public string Scan(string account)
        {
            if (account.Length >= 9)
                return ExtractNumbers(account);
            return string.Empty;
        }

        private string ExtractNumbers(string account) => GetNumericalValue(account) + Scan(_numberExtractor.ExtractOtherNumbers(account));

        private string GetNumericalValue(string account)
        {
            try
            {
                return _ocrNumberDictionary[_numberExtractor.ExtractFirstNumber(account)];
            }
            catch (KeyNotFoundException)
            {
                return "?";
            }
        }
    }
}