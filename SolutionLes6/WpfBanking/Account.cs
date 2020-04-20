using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;


namespace WpfBanking
{
    class Account
    {
        // constructor met één parameter
        public Account(string AccNr)
        {
            AccountNr = AccNr.ToString();

            var regex = @"^\d\d\d-\d\d\d\d\d\d\d-\d\d$";

            var match = Regex.Match(AccountNr, regex, RegexOptions.IgnoreCase);

            if (!match.Success)
            {
                // does not match
            }
        }

        // constructor met twee parameters
        public Account(string AccNr, decimal Bln)
        {
            AccountNr = AccNr;
            Balance = Bln;
        }
       
        // constructor met drie parameters
        public Account(string nummer, string name, int saldo)
        {
            nummer = "";
            name = "";
            saldo = 50;
        }
        public string AccountNr { get; set; }

        public Customer Holder { get; set; }
        public decimal Balance { get; set; } = 0;
      

    }
}
