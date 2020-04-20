using System;
using System.Collections.Generic;
using System.Text;

namespace WpfBanking
{
    class Bank
    {
        public string Name { get; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();
        public Bank(string name)
        {
            Name = name;
        }

        public bool IsHealthy()
        {
            return CalculateGrandTotal() > 0;
        }
        private decimal CalculateGrandTotal()
        {
            decimal total = 0;
            foreach (Account a in Accounts)
            {
                total += a.Balance;
            }
            return total;
        }
        public List<Account> GetAccountsLessThan(decimal amount)
        {
            List<Account> accounts = new List<Account>();
            foreach (Account a in Accounts)
            {
                if (a.Balance < amount) accounts.Add(a);
            }
            return accounts;
        }

    }
}
