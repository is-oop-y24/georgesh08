using System;
using System.Collections.Generic;
using System.Linq;
using Banks.BankFolder;
using Banks.ClientAccount;
using Banks.ClientFolder;

namespace Banks.ConsoleManager
{
    public static class ConsoleUI
    {
        private static CentralBank _cb = CentralBank.GetInstance();
        public static int Launch()
        {
            Console.WriteLine("Central bank initialized.\nRegister new bank first to start.");
            RegisterNewBank();
            while (true)
            {
                Console.Write("Press: 0 - exit,\n1 - register new client,\n2 - register new bank,\n3 - show banks\n");
                string a = Console.ReadLine();
                switch (a)
                {
                    case "0":
                        return 0;
                    case "1":
                        RegisterNewClient();
                        break;
                    case "2":
                        RegisterNewBank();
                        break;
                    case "3":
                        ShowBanks();
                        break;
                }
            }
        }

        private static void ShowBanks()
        {
            foreach (Bank bank in _cb.Banks())
            {
                Console.WriteLine(bank.Name);
            }
        }

        private static void ShowClientAccountsAndBalance(Client client)
        {
            foreach (IClientAccount account in client.Accounts())
            {
                Console.WriteLine(account.AccountNumber.ToString() + " - " + account.Balance);
            }
        }

        private static void RegisterNewClient()
        {
            Console.WriteLine("Enter client's bank\nBank name: ");
            string userAnswer = Console.ReadLine();
            Bank bank = _cb.Banks().FirstOrDefault(bank1 => userAnswer == bank1.Name);

            if (bank == null)
            {
                Console.WriteLine("Bank doesn't exist. Try another one");
                return;
            }

            Console.Write("Enter client's personal data\nName: ");
            string name = Console.ReadLine();
            Console.Write("\nSurname: ");
            string surname = Console.ReadLine();
            Console.Write("\nPassport: ");
            string passport = Console.ReadLine();
            Console.Write("\nAddress: ");
            string address = Console.ReadLine();
            bank.RegisterNewClient(name, surname, passport, address);
        }

        private static void RegisterNewBank()
        {
            Console.WriteLine("Enter new bank name: ");
            string name = Console.ReadLine();
            _cb.RegisterNewBank(name);
        }
    }
}