using System;
using System.Collections.Generic;
using System.Linq;
using Banks.BankAccount;
using Banks.BankFolder;
using Banks.Constants;
using Banks.Tools;

namespace Banks.ClientAccount
{
    public class ClientDepositAccount : IClientAccount
    {
        private BankDepositAccount _bankAccountInstance;
        private double _currentPayment;

        public ClientDepositAccount(BankDepositAccount bankAccount, double balance)
        {
            if (balance < bankAccount.InterestConditions().Keys.First())
            {
                throw new AccountException("Deposit sum is very little to open this type of account");
            }

            AccountNumber = Guid.NewGuid();
            Balance = balance;
            _bankAccountInstance = bankAccount;
        }

        public Guid AccountNumber { get; }
        public double Balance { get; private set; }

        public void WithDrawMoney(double moneyAmount)
        {
            if (_bankAccountInstance.IsActive())
            {
                throw new AccountException("Deposit account is still active. You can't transfer of withdraw money");
            }
        }

        public void DepositMoney(double moneyAmount)
        {
            Balance += moneyAmount;
        }

        public void TransferMoney(Bank bank, Guid to, double moneyAmount)
        {
            if (_bankAccountInstance.IsActive())
            {
                throw new AccountException("Deposit account is still active. You can't transfer of withdraw money");
            }

            bank.TransferMoneyInsideBank(AccountNumber, to, moneyAmount);
        }

        public void TransferMoneyToAnotherBank(CentralBank cb, Bank fromBank, Bank toBank, Guid toAccount, double moneyAmount)
        {
            if (_bankAccountInstance.IsActive())
            {
                throw new AccountException("Deposit account is still active. You can't transfer of withdraw money");
            }

            cb.MakeInterbankTransaction(fromBank, toBank, AccountNumber, toAccount, moneyAmount);
        }

        public double CalculateMoneyAmountInTimePeriod(int days)
        {
            double res = Balance;
            double currentState = _currentPayment;
            for (int i = 0; i < days; ++i)
            {
                CountInterest();
                res += _currentPayment;
            }

            _currentPayment = currentState;
            return res + Balance;
        }

        public void ProceedPayment()
        {
            Balance += _currentPayment;
            _currentPayment = 0;
        }

        public void CountInterest()
        {
            double percentage = 0;
            IReadOnlyDictionary<double, double> conditions = _bankAccountInstance.InterestConditions();
            for (int i = 0; i < conditions.Count - 1; ++i)
            {
                if (!(Balance >= conditions.ElementAt(i).Key) || !(Balance < conditions.ElementAt(i + 1).Key)) continue;
                percentage = conditions.ElementAt(i).Value * Consts.PercentageCoefficient / Consts.DaysInYear;
                _currentPayment = Balance * percentage;
                break;
            }

            if (percentage != 0) return;
            percentage = conditions.Values.Last() * Consts.PercentageCoefficient / Consts.DaysInYear;
            _currentPayment = Balance * percentage;
        }
    }
}