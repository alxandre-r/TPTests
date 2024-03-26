using System.Net.WebSockets;

namespace MortageLoan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Take args from command line and validate them
            Validators.ValidateLoanAmount(int.Parse(args[0]));
            Validators.ValidateNumberOfMonths(int.Parse(args[1]));

            Console.WriteLine("Loan amount: " + args[0]);
            Console.WriteLine("Number of months: " + args[1]);
        }
    }
}