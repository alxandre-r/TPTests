using System.Globalization;

namespace MortageLoan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Validators.ValidateNumberOfArgs(args);
                Validators.ValidateInterestRate(args[2]);

                int loanAmount = int.Parse(args[0]);
                int duration = int.Parse(args[1]);
                decimal rate = decimal.Parse(args[2].Replace(',', '.'), NumberStyles.Float, CultureInfo.InvariantCulture);
                string path = args[3];

                Validators.ValidateLoanAmount(loanAmount);
                Validators.ValidateNumberOfMonths(duration);


                CSVWriter.Write(path, loanAmount, duration, rate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}