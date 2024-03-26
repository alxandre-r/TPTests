namespace MortageLoan
{
    public class InvalidLoanAmountException : Exception
    {
        public InvalidLoanAmountException() : base("Loan amount must be greater than 50 000"){}
    }

    public class InvalidNumberOfMonthsException : Exception
    {
        public InvalidNumberOfMonthsException() : base("Number of months must be between 108 and 225"){}
    }

    public class InvalidInterestRateException : Exception
    {
        public InvalidInterestRateException() : base("Interest rate must be in format xx,xx"){}
    }

    public class InvalidNumberOfArgsException : Exception
    {
        public InvalidNumberOfArgsException() : base("Number of arguments must be 3") { }
    }

    public class InvalidArgsTypeException : Exception
    {
        public InvalidArgsTypeException() : base("Arguments must be numbers") { }
    }
}
