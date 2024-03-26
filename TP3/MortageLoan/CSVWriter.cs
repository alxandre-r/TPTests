namespace MortageLoan
{
    public class CSVWriter
    {
        public static void Write(string path, double totalCost, double monthlyPayment, int duration)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(ICSV.TotalCost(totalCost));
                writer.WriteLine(ICSV.Header());
                
                double remaining = totalCost;
                for (int i = 1; i <= duration; i++)
                {
                    double reimbursed = monthlyPayment * i;
                    remaining -= monthlyPayment;
                    writer.WriteLine(ICSV.Row(i, reimbursed, remaining));
                }

                Console.WriteLine("File created successfully at " + path);
            }
        }
    }
}
