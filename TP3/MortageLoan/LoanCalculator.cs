namespace MortageLoan
{
    public class LoanCalculator
    {

        public static int MontlhyPayment(int loanAmount, int duration, double rate)
        {
            Validators.ValidateLoanAmount(loanAmount);
            Validators.ValidateNumberOfMonths(duration);
            
            return 0;
        }
    }
}
