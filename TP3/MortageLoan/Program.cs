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
                string path = args[3];

                IValidators.ValidateLoanAmount(loanAmount);
                IValidators.ValidateNumberOfMonths(duration);

                double monthlyPayment = LoanCalculator.MontlhyPayment(loanAmount, duration, rate);
                double totalCost = LoanCalculator.TotalPayment(loanAmount, duration, rate);

                CSVWriter.Write(path, totalCost, monthlyPayment, duration);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}