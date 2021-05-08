using System;

namespace BankOCR
{
    public class NumberExtractor : INumberExtractor
    {
        public string ExtractFirstNumber(string input)
        {
            var inputLines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return inputLines[0].Substring(0, 3) + inputLines[1].Substring(0, 3) + inputLines[2].Substring(0, 3);
        }

        public string ExtractOtherNumbers(string input)
        {
            var inputLines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var pendingFirstLine = inputLines[0].Substring(3, inputLines[0].Length - 3);
            var pendingSecondLine = inputLines[1].Substring(3, inputLines[1].Length - 3);
            var pendingThirdLine = inputLines[2].Substring(3, inputLines[2].Length - 3);

            return pendingFirstLine + "\n" + pendingSecondLine + "\n" + pendingThirdLine;
        }
    }
}
