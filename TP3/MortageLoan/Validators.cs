using System.Globalization;

namespace MortageLoan
{
    public static class Validators
    {
        // Loan amount must be greater than 50 000
        public static void ValidateLoanAmount(int loanAmount)
        {
            if (loanAmount < 50000)
            {
                throw new InvalidLoanAmountException();
            }
        }

        // Number of months must be between 108 and 225
        public static void ValidateNumberOfMonths(int months)
        {
            if (months < 108 || months > 225)
            {
                throw new InvalidNumberOfMonthsException();
            }
        }

        // Interest rate must be double
        public static void ValidateInterestRate(string rate)
        {
            double interestRate;
            if (!double.TryParse(rate.Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture, out interestRate))
            {
                throw new InvalidInterestRateException();
            }
        }

        // Number of args must be 4
        public static void ValidateNumberOfArgs(string[] args)
        {
            if (args.Length != 4)
            {
                throw new InvalidNumberOfArgsException();
            }
        }
    }
}
