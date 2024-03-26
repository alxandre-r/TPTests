namespace MortageLoan
{
    public class LoanCalculator
    {

        public static double MontlhyPayment(int loanAmount, int duration, double rate)
        {
            double monthlyRate = rate / 100 / 12;
            double denominator = Math.Pow(1 + monthlyRate, -duration);
            double monthlyPayment = (loanAmount * monthlyRate) / (1 - denominator);

            monthlyPayment = Math.Round(monthlyPayment, 2);
            return monthlyPayment;
        }


        public static double TotalPayment(int loanAmount, int duration, double rate)
        {

            return 0;
        }
    }
}
