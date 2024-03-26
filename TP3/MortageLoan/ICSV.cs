namespace MortageLoan
{
    internal interface ICSV
    {
        public static string TotalCost(double totalCost)
        {
            return "Total cost: " + totalCost;
        }
        public static string Header()
        {
            return "Month;Reimbursed;Remaining";
        }
        public static string Row(int month, double reimbursed, double remaining)
        {
            return month + ";" + reimbursed + ";" + remaining;
        }
    }
}
