using System;

namespace Banks.TransactionFolder
{
    public class ClientTransaction
    {
        public ClientTransaction(Guid from, Guid to, double moneyAmount)
        {
            From = from;
            To = to;
            Sum = moneyAmount;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public Guid From { get; }
        public Guid To { get; }
        public double Sum { get; }
    }
}