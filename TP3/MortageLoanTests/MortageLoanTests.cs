using MortageLoan;

namespace MortageLoanTests
{
    public class InputTests
    {
        [Theory]
        [InlineData(5600)]
        [InlineData(-456)]
        [Trait("Category", "UserInput")]
        public void LoanAmountNotMeetingMinimalRequirement(int loanAmount)
        {
            Assert.Throws<InvalidLoanAmountException>(() => IValidators.ValidateLoanAmount(loanAmount));
        }

        [Theory]
        [InlineData(230)]
        [InlineData(-456)]
        [Trait("Category", "UserInput")]
        public void MonthsNumberNotInRequiredRange(int months)
        {
            Assert.Throws<InvalidNumberOfMonthsException>(() => IValidators.ValidateNumberOfMonths(months));
        }

        [Theory]
        [InlineData("5,5.5")]
        [InlineData("string")]
        [Trait("Category", "UserInput")]
        public void InterestRateNotInCorrectFormat(string rate)
        {
            Assert.Throws<InvalidInterestRateException>(() => IValidators.ValidateInterestRate(rate));
        }
    }

    public class ProgramTests
    {
        [Fact]
        [Trait("Category", "Program")]
        public void NumberOfArgsNotEqualToThree()
        {
            string[] args = new string[] { "50000", "120" };
            Assert.Throws<InvalidNumberOfArgsException>(() => IValidators.ValidateNumberOfArgs(args));
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
        public void MonthlyPaymentCalculation(int loanAmount, int duration, double rate, double expected)
        {
            Assert.Equal(expected, LoanCalculator.MontlhyPayment(loanAmount, duration, rate));
        }

        [Theory]
        [InlineData(50000, 108, 1, 52304.40)]
        [Trait("Category", "Calculation")]
        public void TotalPaymentCalculation(int loanAmount, int duration, double rate, double expected)
        {
            Assert.Equal(expected, LoanCalculator.TotalPayment(loanAmount, duration, rate));
        }
    }
}
