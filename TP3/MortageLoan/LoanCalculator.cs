namespace MortageLoan
{
    public class LoanCalculator
    {
        // TODO : input string to int and double
        private int LoanAmount;
        private int Months;
        private double InterestRate;

        public LoanCalculator(int loanAmount, int months, double interestRate)
        {
            Validators.ValidateLoanAmount(loanAmount);

        }

    }
}
