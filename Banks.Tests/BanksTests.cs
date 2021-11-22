using System;
using System.Collections.Generic;
using System.Linq;
using Banks.BankAccount;
using Banks.BankFolder;
using Banks.ClientFolder;
using Banks.Tools;
using NUnit.Framework;

namespace Banks.Tests
{
    public class BanksTests
    {
        private CentralBank _centralBank;
        private Client.Builder _builder;
        
        [SetUp]
        public void Setup()
        {
            _builder = new Client.Builder();
            _centralBank = CentralBank.GetInstance();
        }

        [Test]
        public void RegisterClientWithoutName_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {
                Client newClient = _builder.SetName("").SetSurname("Shulyak").GetClient();
            });
        }
        
        [Test]
        public void RegisterClientWithoutSurname_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {
                Client newClient = _builder.SetName("George").SetSurname("").GetClient();
            });
        }
        
        [Test]
        public void RegisterClientWithoutPassportOrAddress_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {
                
                Bank newBank = _centralBank.RegisterNewBank("Sber");
                Client newClient = newBank.RegisterNewClient("George", "Shulyak", "", "");
                var newBankAccount = new BankDebitAccount(10000);
                newClient.OpenNewDebitAccount(newBank, newBankAccount, 100000);
            });
        }
        
        [Test]
        public void WithdrawOrTransferMoneyFromDepositAccount_ThrowException()
        {
            Assert.Catch<BanksException>(() =>
            {
                Bank newBank = _centralBank.RegisterNewBank("Sber");
                Client newClient = newBank.RegisterNewClient("George", "Shulyak", "001", "aboba, 25");
                var conditions = new SortedDictionary<double, double>();
                conditions.Add(50000, 3.5);
                conditions.Add(100000, 4);
                var expTime = new DateTime(2022, 5, 27);
                var newBankAccount = new BankDepositAccount(conditions, expTime);
                newClient.OpenNewDepositAccount(newBank, newBankAccount, 100000);
                newClient.WithdrawMoney(newClient.Accounts().First(), 20000);
            });
        }
    }
}