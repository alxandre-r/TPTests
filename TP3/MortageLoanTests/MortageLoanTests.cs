using MortageLoan;

namespace MortageLoanTests
{
    public class MortageLoanTests
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
}