using System;

namespace MortageLoan
{
    public class LoanCalculator
    {
        public static decimal MonthlyPayment(int loanAmount, int duration, decimal annualRate)
        {
            decimal monthlyPayment = loanAmount * (annualRate / 100 / 12) / (decimal)(1 - Math.Pow(1 + (double)(annualRate / 100 / 12), -duration));
            return (decimal)monthlyPayment;
        }

        public static decimal TotalCost(int loanAmount, int duration, decimal annualRate)
        {
            decimal monthlyPayment = MonthlyPayment(loanAmount, duration, annualRate);
            decimal totalCost = monthlyPayment * duration;

            return (decimal)totalCost;
        }
    }
}
