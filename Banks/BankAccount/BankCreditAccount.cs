namespace Banks.BankAccount
{
    public class BankCreditAccount
    {
        public BankCreditAccount(double commission)
        {
            Commission = commission;
        }

        public double Commission { get; private set; }

        public void ChangeCommission(double newValue)
        {
            Commission = newValue;
        }
    }
}