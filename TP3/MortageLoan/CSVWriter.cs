using System;
using System.IO;

namespace MortageLoan
{
    public class CSVWriter
    {
        public static void Write(string path, int loanAmount, int duration, decimal rate)
        {
            decimal monthlyPayment = LoanCalculator.MonthlyPayment(loanAmount, duration, rate);
            decimal totalCost = LoanCalculator.TotalCost(loanAmount, duration, rate);
            
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine($"Loan amount: {loanAmount}");
                writer.WriteLine($"Duration: {duration} months");
                writer.WriteLine($"Annual interest rate: {rate}%");

                writer.WriteLine($"Total cost: {totalCost}");
                writer.WriteLine("Month, Reimbursed, Remaining");

                decimal remaining = totalCost;
                decimal reimbursed = 0;
                decimal totalInterest = 0;
                decimal totalReimbursed = 0;

                for (int i = 1; i <= duration; i++)
                {
                    decimal interestThisMonth = remaining * rate / 100 / 12;
                    decimal reimbursedThisMonth = monthlyPayment - interestThisMonth;
                    totalReimbursed = reimbursed + reimbursedThisMonth;
                    totalInterest += interestThisMonth;
                    remaining -= reimbursedThisMonth - interestThisMonth;
                    
                    writer.WriteLine($"{i}, {totalReimbursed}, {remaining}");
                }

                Console.WriteLine("File created successfully at " + path);
            }
        }
    }
}
