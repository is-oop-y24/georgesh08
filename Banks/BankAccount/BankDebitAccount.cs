namespace Banks.BankAccount
{
    public class BankDebitAccount : IBankAccount
    {
        public BankDebitAccount(double interestOnBalance)
        {
            InterestOnBalance = interestOnBalance;
        }

        public double Commission { get; } = 0;

        public double InterestOnBalance { get; private set; }

        public void ChangeInterestOnBalance(double newInterest)
        {
            InterestOnBalance = newInterest;
        }
    }
}