using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Banks.ClientAccount;
using Banks.TransactionFolder;

namespace Banks.BankFolder
{
    public sealed class CentralBank
    {
        private static CentralBank _instance;
        private List<Bank> _banks = new List<Bank>();
        private CentralBank() { }

        public static CentralBank GetInstance()
        {
            return _instance ??= new CentralBank();
        }

        public void MakeInterbankTransaction(Bank bankFrom, Bank toBank, Guid from, Guid to, double moneyAmount)
        {
            GetAccountFromBank(bankFrom, from).WithDrawMoney(moneyAmount);
            GetAccountFromBank(toBank, to).DepositMoney(moneyAmount);
            bankFrom.RegisterTransaction(from, to, moneyAmount);
            toBank.RegisterTransaction(from, to, moneyAmount);
        }

        public void CancelTransaction(Bank withdrawalBank, Guid transactionId)
        {
            ClientTransaction transaction =
                withdrawalBank.Transactions().FirstOrDefault(trans => transactionId.Equals(trans.Id));

            if (transaction == null)
            {
                throw new TransactionException("Wrong transaction number");
            }

            IClientAccount withdrawalAccount = withdrawalBank.GetAccountByAccountNumber(transaction.From);
            withdrawalAccount.DepositMoney(transaction.Sum);
        }

        public Bank RegisterNewBank(string name)
        {
            var newBank = new BankFolder.Bank(name);
            _banks.Add(newBank);
            return newBank;
        }

        public void NotifyAboutPayment()
        {
            foreach (Bank bank in _banks)
            {
                bank.MakePayment();
            }
        }

        public IReadOnlyList<Bank> Banks()
        {
            return _banks;
        }

        private IClientAccount GetAccountFromBank(Bank bank, Guid accountNum)
        {
            return bank.GetAccountByAccountNumber(accountNum);
        }
    }
}