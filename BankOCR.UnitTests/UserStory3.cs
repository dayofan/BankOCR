using BankOCR;
using NUnit.Framework;

namespace BankOcrKata
{
    public class UserStory3
    {
        [TestCase(@"
 _  _  _  _  _  _  _  _     
| || || || || || || ||_   |
|_||_||_||_||_||_||_| _|  |", "000000051")]
        [TestCase(@"
    _  _  _  _  _  _     _ 
|_||_|| || ||_   |  |  | _ 
  | _||_||_||_|  |  |  | _|", "49006771? ILL")]
        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_| _ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _ ", "1234?678? ILL")]
        [TestCase(@"
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_||_|", "123456788 ERR")] // new test case
        public void Tests(string input, string expectedResult)
        {
            // Arrange
            var sut = new OcrReportingService(new AccountNumberValidator());
            var scanner = new Scanner(new NumberExtractor());
            var accountNumber = scanner.Scan(input);

            // Act
            var result = sut.GenerateReport(accountNumber);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}