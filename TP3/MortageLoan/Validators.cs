using System.Globalization;

namespace MortageLoan
{
    public class Validators
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

        // Number of args must be 3
        public static void ValidateNumberOfArgs(string[] args)
        {
            if (args.Length != 3)
            {
                throw new InvalidNumberOfArgsException();
            }
        }

        // Args must not be int or double
        public static void ValidateArgsType(string[] args)
        {
            foreach (var arg in args)
            {
                if (!int.TryParse(arg, out int _))
                {
                    if (!double.TryParse(arg.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double _))
                    {
                        throw new InvalidArgsTypeException();
                    }
                }
            }
        }


    }
}
