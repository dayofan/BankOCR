using System;
using System.Linq;

namespace BankOCR
{
    public class AccountNumberValidator : IAccountNumberValidator
    {
        public bool Validate(string accountNumberString)
        {
            if (accountNumberString.Length != 9) return false;
            var oneToNineArray = Enumerable.Range(1, 9).ToArray();
            var reversedString = accountNumberString.Reverse();
            var reversedIntegerArray = reversedString.Select(s => (int)char.GetNumericValue(s)).ToArray();

            var dotProduct = reversedIntegerArray.Zip(oneToNineArray, (d1, d2) => d1 * d2).Sum();

            var checksum = dotProduct % 11;

            return checksum == 0;
        }
    }
}
