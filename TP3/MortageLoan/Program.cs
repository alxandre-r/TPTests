using System.Globalization;

namespace MortageLoan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IValidators.ValidateNumberOfArgs(args);
                IValidators.ValidateInterestRate(args[2]);

                int loanAmount = int.Parse(args[0]);
                int duration = int.Parse(args[1]);
                double rate = double.Parse(args[2].Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);



                IValidators.ValidateLoanAmount(loanAmount);
                IValidators.ValidateNumberOfMonths(duration);

                Console.WriteLine("Loan amount: " + args[0]);
                Console.WriteLine("Number of months: " + args[1]);
                Console.WriteLine("Interest rate: " + args[2]);

                Console.WriteLine("Monthly payment: " + LoanCalculator.MontlhyPayment(loanAmount, duration, rate));
                Console.WriteLine("Total payment: " + LoanCalculator.TotalPayment(loanAmount, duration, rate));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}