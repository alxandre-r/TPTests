namespace MortageLoan
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Validators.ValidateNumberOfArgs(args);
                Validators.ValidateArgsType(args);

                Console.WriteLine("Loan amount: " + args[0]);
                Console.WriteLine("Number of months: " + args[1]);
                Console.WriteLine("Interest rate: " + args[2]);

                Console.WriteLine("Monthly payment: " + LoanCalculator.MontlhyPayment(int.Parse(args[0]), int.Parse(args[1]), double.Parse(args[2])));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}