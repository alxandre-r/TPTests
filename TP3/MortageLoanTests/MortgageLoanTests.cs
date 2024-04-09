using MortageLoan;

namespace MortgageLoanTests
{
    public class InputTests
    {
        [Theory]
        [InlineData(5600)]
        [InlineData(-456)]
        [Trait("Category", "UserInput")]
        public void LoanAmountNotMeetingMinimalRequirement(int loanAmount)
        {
            Assert.Throws<InvalidLoanAmountException>(() => Validators.ValidateLoanAmount(loanAmount));
        }

        [Theory]
        [InlineData(230)]
        [InlineData(-456)]
        [Trait("Category", "UserInput")]
        public void MonthsNumberNotInRequiredRange(int months)
        {
            Assert.Throws<InvalidNumberOfMonthsException>(() => Validators.ValidateNumberOfMonths(months));
        }

        [Theory]
        [InlineData("5,5.5")]
        [InlineData("string")]
        [Trait("Category", "UserInput")]
        public void InterestRateNotInCorrectFormat(string rate)
        {
            Assert.Throws<InvalidInterestRateException>(() => Validators.ValidateInterestRate(rate));
        }
    }

    public class ProgramTests
    {
        [Fact]
        [Trait("Category", "Program")]
        public void NumberOfArgsNotEqualToThree()
        {
            string[] args = new string[] { "50000", "120" };
            Assert.Throws<InvalidNumberOfArgsException>(() => Validators.ValidateNumberOfArgs(args));
        }
    }

    public class LoanCalculatorTests
    {
        [Theory]
        [InlineData(200_000, 300, 3.92, 1046.86)]
        [InlineData(50_000, 108, 0.62, 476.12)]
        [InlineData(67854, 200, 0.91, 365.78)]
        [InlineData(1000000, 156, 1.15, 6904.42)]
        [Trait("Category", "Calculation")]
        public void MonthlyPaymentCalculation(int loanAmount, int duration, decimal rate, decimal expected)
        {
            Assert.Equal(expected, LoanCalculator.MonthlyPayment(loanAmount, duration, rate));
        }

        [Theory]
        [InlineData(50000, 108, 1, 52304.40)]
        [Trait("Category", "Calculation")]
        public void TotalPaymentCalculation(int loanAmount, int duration, decimal rate, decimal expected)
        {
            Assert.Equal(expected, LoanCalculator.TotalCost(loanAmount, duration, rate));
        }
    }

    public class CSVTests
    {
        [Fact]
        [Trait("Category", "CSV")]
        public void CSVFileIsCreated()
        {
            string path = "C:\\Temp\\mortgage.csv";
            int loanAmount = 50000;
            int duration = 120;
            decimal rate = 4.15m;

            CSVWriter.Write(path, loanAmount, duration, rate);

            Assert.True(File.Exists(path));
        }

        [Fact]
        [Trait("Category", "CSV")]
        public void Write_ChecksFileContent()
        {
            string path = "C:\\Temp\\mortgage.csv";
            int loanAmount = 10000;
            int duration = 12;
            decimal rate = 4.15m;

            CSVWriter.Write(path, loanAmount, duration, rate);

            string[] lines = File.ReadAllLines(path);
            // cost assertion
            Assert.Contains("Total cost: 10000", lines[0]);
            // Header 
            Assert.Equal("Month;Reimbursed;Remaining", lines[1]);
            // Row
            for (int i = 1; i <= duration; i++)
            {
                Assert.Contains($"{i};", lines[i + 1]);
            }
        }
    }
}
