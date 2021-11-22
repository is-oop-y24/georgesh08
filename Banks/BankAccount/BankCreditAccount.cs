namespace Banks.BankAccount
{
    public class BankCreditAccount : IBankAccount
    {
        public BankCreditAccount(double commission)
        {
            Commission = commission;
        }

        public double Commission { get; private set; }
        public double InterestOnBalance { get; } = 0;

        public void ChangeInterestOnBalance(double newValue)
        {
            Commission = newValue;
        }
    }
}