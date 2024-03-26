namespace MortageLoan
{
    public class InvalidLoanAmountException : Exception
    {
        public InvalidLoanAmountException() : base("Loan amount must be greater than 50 000")
        {
        }
    }

    public class InvalidNumberOfMonthsException : Exception
    {
        public InvalidNumberOfMonthsException() : base("Number of months must be between 108 and 225")
        {
        }
    }
}
