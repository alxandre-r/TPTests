namespace MortageLoan
{
    public class Validators
    {
        public static void ValidateLoanAmount(int loanAmount)
        {
            if (loanAmount < 50000)
            {
                // Display error message
                throw new InvalidLoanAmountException();
            }
        }

        public static void ValidateNumberOfMonths(int months)
        {
            if (months < 108 || months > 225)
            {
                throw new InvalidNumberOfMonthsException();
            }
                    
        }


    }
}
