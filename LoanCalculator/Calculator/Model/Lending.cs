
namespace Calculator.Model
{
    internal class Lending
    {
        public decimal Amount { get; set; }
        public decimal Rate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal MonthlyAmount { get; set; }

        public Lending(decimal amount, decimal rate, decimal totalAmount, decimal monthlyAmount)
        {
            Rate = rate;
            Amount = amount;
            TotalAmount = totalAmount;
            MonthlyAmount = monthlyAmount;
        }
    }
}
