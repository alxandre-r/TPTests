using MortageLoan;

namespace MortageLoanTests
{
    public class InputTests
    {
        [Theory]
        //[InlineData(56000)]
        [InlineData(5600)]
        [InlineData(-456)]
        [Trait("Category", "UserInput")]
        public void LoanAmountNotMeetingMinimalRequirement(int loanAmount)
        {
            Assert.Throws<InvalidLoanAmountException>(() => Validators.ValidateLoanAmount(loanAmount));
        }

        [Theory]
        //[InlineData(108)]
        [InlineData(230)]
        [InlineData(-456)]
        [Trait("Category", "UserInput")]
        public void MonthsNumberNotInRequiredRange(int months)
        {
            Assert.Throws<InvalidNumberOfMonthsException>(() => Validators.ValidateNumberOfMonths(months));
        }
    }
    // Test si le nombre d'argument est bien 3
    public class ProgramTests
    {
        [Fact]
        [Trait("Category", "Program")]
        public void NumberOfArgsNotEqualToThree()
        {
            string[] args = new string[] { "50000", "120" };
            Assert.Throws<InvalidNumberOfArgsException>(() => Validators.ValidateNumberOfArgs(args));
        }

        [Fact]
        [Trait("Category", "UserInput")]
        public void ArgsTypeIsNotNumber()
        {
            string[] args = new string[] { "50000", "108", "5.5" };
            Assert.Throws<InvalidArgsTypeException>(() => Validators.ValidateArgsType(args));
        }
    }

    public class LoanCalculatorTests
    {
        [Fact]
        [Trait("Category", "Calculation")]
        public void MonthlyPaymentCalculation()
        {
            int loanAmount = 50000;
            int duration = 108;
            double rate = 5.5;
            Assert.Equal(0, LoanCalculator.MontlhyPayment(loanAmount, duration, rate));
        }
    }
}
