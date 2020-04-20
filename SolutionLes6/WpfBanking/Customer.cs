using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail; // manueel toevoegen

namespace WpfBanking
{
    class Customer
    {
        public Customer()
        {
            registerDate = DateTime.Now;
        }

        // constructor met parameters
        public Customer(string fn, string ln)
        {
            registerDate = DateTime.Now;
            FirstName = fn;
            LastName = ln;
            Rating = (new Random()).Next(1, 6);
        }
        // constructor met parameters
        public Customer(string fn, string ln, int rt)
        {
            registerDate = DateTime.Now;
            FirstName = fn;
            LastName = ln;
            Rating = rt;
        }

        private string _email;
        private int _rating = 3;
        private DateTime registerDate;
        public int ClientId { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email
        {
            get { return _email; }
            set
            {
                try
                {
                    MailAddress m = new MailAddress(value);
                    _email = value;
                }
                catch (FormatException)
                {
                    throw new ArgumentException($"ongeldig email");
                }
            }
        }
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentOutOfRangeException(
                    $"rating moet tussen 1 en 5 liggen");
                }
                _rating = value;
            }
        }
        
    }
}

